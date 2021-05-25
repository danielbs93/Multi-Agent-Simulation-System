﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class SokobanManager : MonoBehaviour
{

    //Objects
    public GameObject simulationManager;

    public GameObject maphold;

    public GameObject agent;
    public GameObject wall;
    public GameObject box;
    public GameObject goal;
    public GameObject floor;
    public Text actionNumber;


    public GameObject[] agents;
    public GameObject[] walls;
    public GameObject[] boxes;
    public GameObject[] goals;
    public GameObject[] floors;

/*
    ===================CAMERAS=====================
    */
    private Queue<Camera> cameraQueue;
    private Camera activeCameraObject;
    private bool cameras_initiated = false;
    //Mouse scroll wheel adjustments
    private float minFov = 15f;
    private float maxFov = 90f;
    private float sensitivity = 10f;

    //Fields
    
    private sokobanParser sokobanParser;// = new sokobanParser("C:\\Users\\alona\\Desktop\\Studies\\p05");

    private sokobanPlanParser sokobanPlanParser;
    public SimulationObject[,,] map;

    // Step by Step mode or continuus running
    private bool gameHold = false;
    private bool stepFlag = false;
    private bool backWardStep = false;

    // private Animator anim;
    private CharacterController controller;

    private bool controlEnabled = false; // Face Camera option was clicked ('c' in keyboard)
    private bool keyboardPlayer = true; // Prototype option - Agent moves currently with the 

    private List<Action> actions; // List of agents actions from the plan file 

    private string initPath;
    // private string preEffPath;
    private string planPath;

    private int frames = 0;
    [SerializeField]
    public float simulationSpeed = 30;

    int blockSize = 1;  // size of each block

    int actionCounter = 0;
    private int previousAnimatorIndex = -1;
    float rotationTime = 90f;

    private UnityEngine.UI.Slider slider;
    private Dictionary<int,String> agentsLastDirections;

    // public float speed = 600.0f;
    // public float turnSpeed =600.0f;
    // private Vector3 moveDirection = Vector3.zero;
    // public float gravity = 20.0f;

    // Use this for initialization
    void Start()
    {
        actionNumber = GameObject.Find("ActionNumber").GetComponent<Text>();
    }

    public void setSokobanPaths(string init, string plan)
    {
        initPath = init;
        // preEffPath = preEff;
        planPath = plan;
    }

    public void initParser()
    {
        sokobanParser = new sokobanParser(initPath);
    }

    public void planParser()
    {
        sokobanPlanParser = new sokobanPlanParser(planPath);
    }


    // Initiate Game Objects at their positions
    public void setmap()
    {
        maphold.SetActive(true);
        // slider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
        
        //------GenerateMap - 3D by the parser with SimulationObject-------
        //map = sokoban_Parser.generateMap();

        //------generating map of char array by the parser---------
        SimulationObject[,,] char_map = sokobanParser.initializeMap();

        actions = sokobanPlanParser.getActions();

        int countbox = Convert.ToInt32(sokobanParser.information["numOfStones"]); // # of boxes / goals
        int countwall = Convert.ToInt32(sokobanParser.information["numOfWalls"]); 
        int countgoal = Convert.ToInt32(sokobanParser.information["numOfGoals"]);
        int countAgents = Convert.ToInt32(sokobanParser.information["numberOfPlayers"]);
        int countFloor = char_map.GetLength(1) * char_map.GetLength(2);
        // -------Generate map by the MapGenerator class-------
        #region
        //MapGenerator mg = new MapGenerator();
        //char[,,] char_map = mg.GenerateMap(1);
        //int countbox = 0; // # of boxes / goals
        //int countwall = 0;
        //int countgoal = 0;
        //int countAgents = 0;
        //int countfloors = 0;

        //foreach (SimulationObject c in char_map){
        //    if (c.getName() == "b")
        //        countbox++;
        //    if (c.getName() == "w")
        //        countwall++;
        //    if (c.getName() == "g")
        //        countgoal++;
        //    if (c.getName() == "h")
        //        countAgents++;
        //    if (c.getName() == "f")
        //        countfloors++;
        //}
        #endregion

        //Initializing setting before drawing the objects in unity 
        if (boxes != null && goals != null)
        {
            wall.SetActive(true);
            box.SetActive(true);
            agent.SetActive(true);
            goal.SetActive(true);
            floor.SetActive(true);

            foreach (Transform child in maphold.transform)
            {
                Destroy(child.gameObject);
            }
        }
        boxes = new GameObject[countbox];
        goals = new GameObject[countgoal];
        walls = new GameObject[countwall];
        agents = new GameObject[countAgents];
        floors = new GameObject[countFloor];

        agentsLastDirections = new Dictionary<int, string>();
        for(int i=0; i<countAgents; i++){
            agentsLastDirections.Add(i,"up");
        }
        //-----Drawing map by SimulationObjects map recieved from the parser------
        DrawMap(char_map);

        //----Drawing map with char array recieved from the parser-----
        //DrawCharMap(char_map);
        
        Deactivate(box);
        Deactivate(wall);
        Deactivate(floor);
        //Deactivate(agent);
        Deactivate(goal);

        // actions = parser Plan file
        // AgentMovements(actions);
        

    }

    // Agents moves
    void Update()
    {
        Action action = null;
        if (goals.Length != 0 && checkwin())
        {
            Deactivate(agent);
            maphold.SetActive(false);
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
            controlEnabled = !controlEnabled;

        if (keyboardPlayer)
        {
            if (!controlEnabled)
            {
                // AgentMovements(false);
            }
        }
        //Switching cameras
        if(Input.GetMouseButtonDown(1)) 
        {
            switchCameras();
        }

        //Mouse Scroll Wheel zoom-in and zoom-out
        float fov = activeCameraObject.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        activeCameraObject.fieldOfView = fov;

        // Since Update function occures every 1 frame we had to control the simulation speed by 'frame' variable
        frames++;
        if (frames%simulationSpeed == 0)
        {
            // Iterating over the agents actions
            if (actionCounter < actions.Count && (gameHold == stepFlag || gameHold == backWardStep))
            {
                if (actionCounter >= 0) { action = actions[actionCounter]; }
                
                if(action != null && gameHold == stepFlag)
                {
                    if (gameHold == stepFlag)
                    {
                        AgentMovements(action);
                        actionCounter++;
                        if (gameHold && stepFlag)
                        {
                            stepFlag = !stepFlag;
                        }
                    }
                }
                else if (action != null && gameHold == backWardStep)
                {
                    if (actionCounter >= 0)
                    {
                        actionNumber.text = actionCounter.ToString();

                        // Checking if a box was moved too
                        Vector3 originalDir = GetTranspositionVector(action);
                        int index = Convert.ToInt32(action.getId()) - 1;
                        GameObject boxWasMoved = GetBoxInPosition(agents[index].GetComponent<Transform>().position + originalDir);

                        // Reversing the action
                        Action reversedAction = ReverseActionProperties(action);
                        Vector3 reverseDirection = GetTranspositionVector(reversedAction);
                        ReturnToFormerPositions(reversedAction, reverseDirection, boxWasMoved);// switch to new function of just placing the objects in their former state
                    }

                    if (gameHold && backWardStep)
                    {
                        backWardStep = !backWardStep;
                    }
                }
            }
            // Stop animation of last agent
            else if (actionCounter == actions.Count)
            {
                Animator currentAnimator = agents[previousAnimatorIndex].GetComponent<Animator>();
                currentAnimator.SetInteger("AnimationPar", 0);
                actionCounter++;
            }
            frames = 0;
        }
    }

    /*
     Returning the game objects positions to the former state
     */
    private void ReturnToFormerPositions(Action reversedAction, Vector3 reverseDirection, GameObject boxWasMoved)
    {
        int index = Convert.ToInt32(reversedAction.getId()) - 1;
        agents[index].GetComponent<Transform>().position += reverseDirection;
        if (boxWasMoved != null)
        {
            boxWasMoved.GetComponent<Transform>().position += reverseDirection;
        }
    }

    /*
     Reverse the properties of an action 
     */
    private Action ReverseActionProperties(Action action)
    {
        string reverseDirection = ReverseDirection(action.getDirection());
        return new Action(action.getId(), action.getDescription(), reverseDirection);
    }

    /*
     Return the opposite direction the agent went to illustrate backward step
     */
    private string ReverseDirection(string v)
    {
        if (v.Equals("right"))
        {
            return "left";
        }
        else if (v.Equals("left"))
        {
            return "right";
        }
        else if (v.Equals("up"))
        {
            return "down";
        }
        else if (v.Equals("down"))
        {
            return "up";
        }
        else
            return null;
    }

    /*
     Translate the direction needed to backward from string into vector
     */
    private Vector3 GetTranspositionVector(Action action)
    {
        string v = action.getDirection();
        if (v.Equals("right"))
        {
            return new Vector3(0, 0, 1);
        }
        if (v.Equals("left"))
        {
            return new Vector3(0, 0, -1);
        }
        if (v.Equals("up"))
        {
            return new Vector3(-1, 0, 0);
        }
        if (v.Equals("down"))
        {
            return new Vector3(1, 0, 0);
        }
        return new Vector3(0, 0, 0);
    }

    private void DrawMap(SimulationObject[,,] map)
    {
        int flagBoxes = 0;
        int flagGoals = 0;
        int flagWall = 0;
        int flagAgents = 0;
        int flagFloors= 0;
        for (int y = 0; y < map.GetLength(0) - 1 ; y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int z = 0; z < map.GetLength(2); z++)
                {
                    GameObject g = null;
                    if (isWall(map[y, x, z]))
                    {
                        g = Instantiate(wall);
                        walls[flagWall] = g;                 
                        InitializeWall(walls[flagWall], x, y, z);
                        flagWall++;

                    }
                    if (isFloor(map[y, x, z]))
                    {
                        g = Instantiate(floor);
                        floors[flagFloors] = g;                 
                        InitializeFloor(floors[flagFloors], x, y, z);
                        flagFloors++;
                    }
                    if (isBox(map[y, x, z]))
                    {
                        g = Instantiate(box);
                        boxes[flagBoxes] = g;
                        InitializeCube(boxes[flagBoxes], x, y, z);
                        flagBoxes++;
                    }
                    if (isGoal(map[y, x, z]))
                    {
                        g = Instantiate(goal);
                        goals[flagGoals] = g;
                        InitializeCube(goals[flagGoals], x, y, z);
                        flagGoals++;
                    }
                    if (isAgent(map[y, x, z]))
                    {
                        g = Instantiate(agent);
                        print(Convert.ToInt32(map[y, x, z].getID()));
                        print(map[y, x, z].getID());
                        print("------------------");
                        agents[Convert.ToInt32(map[y, x, z].getID())-1] = g;
                        InitializeWorker(agents[Convert.ToInt32(map[y, x, z].getID())-1], x, y, z);
                        flagAgents++;
                    }
                    if (g != null)
                        g.transform.parent = maphold.transform;
                }
            }
        }
    }


    /**
     * This function responsible for the ai agent moves.
     * 
     * Boolean 'isAgent' represent if the prototype currently is on - keyboard agent movement,
     * or the agent moves autonomously.
     * 
     */
    private void AgentMovements(Action action)
    {
        actionNumber.text = actionCounter.ToString();
        int index = Convert.ToInt32(action.getId())-1;
        string value = action.getDirection();
        controller = GetComponent <CharacterController>();
        Animator[] anim = gameObject.GetComponentsInChildren<Animator>();

        // Starting cuurent agent animation and stopping the former agent animation
        if (previousAnimatorIndex != index && previousAnimatorIndex != -1)
        {
            anim[previousAnimatorIndex].SetInteger("AnimationPar", 0);
            anim[index].SetInteger ("AnimationPar", 1);
        }

        // If it is the first action and the first agent that is moving then start its animation
        if (previousAnimatorIndex == -1)
        {
            anim[index].SetInteger("AnimationPar", 1);
        }

        if (value.Equals("right"))
        {
            CheckBoxMovment(agents[index].GetComponent<Transform>().position, new Vector3(0, 0, 1));
            agents[index].transform.rotation = Quaternion.Lerp(agents[index].transform.rotation
                                                    ,Quaternion.LookRotation(new Vector3(0, 0, 1)), Time.deltaTime*rotationTime);
            agents[index].GetComponent<Transform>().position += new Vector3(0, 0, 1);
        }
        if (value.Equals("down"))
        {
            CheckBoxMovment(agents[index].GetComponent<Transform>().position, new Vector3(1, 0, 0));
            agents[index].transform.rotation = Quaternion.Lerp(agents[index].transform.rotation
                                                    ,Quaternion.LookRotation(new Vector3(1, 0, 0)), Time.deltaTime*rotationTime);
            agents[index].GetComponent<Transform>().position += new Vector3(1, 0, 0);
        }
        if (value.Equals("left"))
        {
            CheckBoxMovment(agents[index].GetComponent<Transform>().position, new Vector3(0, 0, -1));
            agents[index].transform.rotation = Quaternion.Lerp(agents[index].transform.rotation
                                                    ,Quaternion.LookRotation(new Vector3(0, 0, -1)), Time.deltaTime*rotationTime);
            agents[index].GetComponent<Transform>().position += new Vector3(0, 0, -1);

        }
        if (value.Equals("up"))
        {
            CheckBoxMovment(agents[index].GetComponent<Transform>().position, new Vector3(-1, 0, 0));
            agents[index].transform.rotation = Quaternion.Lerp(agents[index].transform.rotation
                                                    ,Quaternion.LookRotation(new Vector3(-1, 0, 0)), Time.deltaTime*rotationTime);
            agents[index].GetComponent<Transform>().position += new Vector3(-1, 0, 0);
        }

        previousAnimatorIndex = index;
    }

    /*** This function check if in the agent moves he pushes box
     *
     * 
     */
    private void CheckBoxMovment (Vector3 position, Vector3 move)
    {
        foreach (GameObject tbox in boxes)
        {
            if (position + move == tbox.GetComponent<Transform>().position)
            {
                //ValidifyMove(tbox, new Vector3(-1, 0, 0));
                tbox.GetComponent<Transform>().position += move;
            }
        }
    }

    // public void adjustSpeed() {
    //     float newSpeed = slider.value;
    //     print(newSpeed);
    //     this.simulationSpeed = newSpeed;
    // }

    // private float setAgentsRotation(int agentIndex, String direction){
    //     String lastDir = agentsLastDirections[agentIndex];
    //     if(lastDir.Equals("up")){

    //     }
        
    // }


    /*
     * This function checks if all boxes are in their goal positions
     */
    // bool checkwin()
    // {
    //     int goalflags = 0;
    //     float y_goal_box = 0.5f;
    //     foreach (GameObject tgoal in goals)
    //         foreach (GameObject tbox in boxes)
    //         {
    //             // Since the goal is ObjectGame at position (0,0.5,0) we check the addition of goal position to the box position
    //             if ((tgoal.GetComponent<Transform>().position + new Vector3(0, y_goal_box, 0)).Equals(tbox.GetComponent<Transform>().position))
    //                 goalflags++;
    //         }
    //     if (goals.Length == goalflags)
    //         return true;
    //     return false;
    // }
     bool checkwin()
    {
        int goalflags = 0;
        // float y_goal_box = 0.5f;
        /*
        foreach (GameObject tgoal in goals)
            foreach (GameObject tbox in boxes)
            {
                // Since the goal is ObjectGame at position (0,0.5,0) we check the addition of goal position to the box position
                if ((tgoal.GetComponent<Transform>().position + new Vector3(0, y_goal_box, 0)).Equals(tbox.GetComponent<Transform>().position))
                    goalflags++;
            }
        
        */
        if (goals.Length == goalflags)
            return true;
            
        return false;
    }



    void InitializeWall(GameObject box, int x, int y, int z)
    {
        Vector3 size = box.GetComponent<Renderer>().bounds.size;
        box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.x, blockSize / size.y, blockSize / size.z);
        box.GetComponent<Transform>().position = new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void InitializeFloor(GameObject box, int x, int y, int z)
    {
        Vector3 size = box.GetComponent<Renderer>().bounds.size;
        box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.x, blockSize / size.y, blockSize / size.z);
        box.GetComponent<Transform>().position = new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void InitializeCube(GameObject box, int x, int y, int z)
    {
        // box.AddComponent<MeshRenderer>();
        // // box.AddComponent<LineRenderer>();
        // Vector3 size = box.GetComponent<Renderer>().bounds.size;
        // print( box.GetComponent<Renderer>());
        // box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.x, blockSize / size.y, blockSize / size.z);
        box.GetComponent<Transform>().position += new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void InitializeWorker(GameObject box, int x, int y, int z)
    {
        // box.AddComponent<MeshRenderer>();
        // Vector3 size = box.GetComponent<Renderer>().bounds.size;
        // box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.y, blockSize / size.y, blockSize / size.y);
        box.GetComponent<Transform>().position = new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void Deactivate(GameObject o)
    {
        o.SetActive(false);
    }

    void Deactivate(GameObject[] arr)
    {
        foreach (GameObject o in arr)
            o.SetActive(false);
    }

    private void DestroyObjects(GameObject[] arr)
    {
        foreach (GameObject o in arr)
            Destroy(o);
    }

    public void deleteMap()
    {
        //Deactivate(walls);
        Deactivate(wall);
        //Deactivate(floors);
        Deactivate(floor);
        //Deactivate(goals);
        Deactivate(goal);
        //Deactivate(agents);
        Deactivate(agent);
        //Deactivate(boxes);
        Deactivate(box);
        DestroyObjects(walls);
        DestroyObjects(floors);
        DestroyObjects(agents);
        DestroyObjects(boxes);

    }


    /*
     * Validating Agent movements:
     *      illegal move: through walls, through boxes where there is walls after it.
     *      legal move: clear step ahead, box with clear step after it .
     */
    void ValidifyMove(GameObject o, Vector3 mov)
    {
        Vector3 pos = o.GetComponent<Transform>().position + mov;
        if (wallInPosition(pos))
            return;
        if (boxInPosition(pos))
        {
            Vector3 nextPos = pos + mov;
            if (wallInPosition(nextPos) || boxInPosition(nextPos))
                return;
        }
        o.GetComponent<Transform>().position += mov;
    }

    /*
     Return the box game object in the given position else null
     */
    private GameObject GetBoxInPosition(Vector3 pos)
    {
        foreach (GameObject box in boxes)
        {
            if (box.GetComponent<Transform>().position == pos)
                return box;
        }
        return null;
    }

    /*
     * Returns true if there is a box in the given position 
     * */
    private bool boxInPosition(Vector3 pos)
    {
        foreach (GameObject box in boxes)
        {
            if (box.GetComponent<Transform>().position == pos)
                return true;
        }
        return false;
    }

    /**
     * Returns true if there is a wall in the given position
     * */
    private bool wallInPosition(Vector3 pos)
    {
        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<Transform>().position == pos)
                return true;
        }
        return false;
    }

    // checks if the simulation objects in the map is a wall
    private bool isWall(SimulationObject obj)
    {
        if (obj.getName().Equals("w"))
        {
            return true;
        }
        return false;
    }
    
    // checks if the simulation objects in the map is a wall
    private bool isFloor(SimulationObject obj)
    {
        if (obj.getName().Equals("f"))
        {
            return true;
        }
        return false;
    }

    //checks if the simulation object in the map is an agent
    private bool isAgent(SimulationObject obj)
    {
        if (obj.getName().Equals("h"))
        {
            return true;
        }
        return false;
    }
    
    //checks if the simulation object in the map is a goal
    private bool isGoal(SimulationObject obj)
    {
        if (obj.getName().Equals("g"))
        {
            return true;
        }
        return false;
    }

    //checks if the simulation object in the map is a box
    private bool isBox(SimulationObject obj)
    {
        if (obj.getName().Equals("b"))
        {
            return true;
        }
        return false;
    }

    public void initCamerasQueue()
    {
        if (!cameras_initiated)
        {
            cameraQueue = new Queue<Camera>();

            activeCameraObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
            GameObject[] sideCameras = GameObject.FindGameObjectsWithTag("SideCamera");

            foreach (GameObject g_camera in sideCameras)
            {
                Camera camera = g_camera.GetComponent<Camera>();
                camera.gameObject.SetActive(false);
                cameraQueue.Enqueue(camera);
            }

            cameras_initiated = true;
        }

    }

    public void switchCameras()
    {
        Camera tempCamera = activeCameraObject;
        activeCameraObject.gameObject.SetActive(false);
        activeCameraObject = cameraQueue.Dequeue();
        activeCameraObject.gameObject.SetActive(true);
        Canvas spaceCanvas = GameObject.FindGameObjectWithTag("SpaceCanvas").GetComponent<Canvas>() as Canvas;
        spaceCanvas.worldCamera = activeCameraObject;
        cameraQueue.Enqueue(tempCamera);
    }

    /*
     Simulation tranformation to continuus running
     */
    public void playSimMode()
    {
        gameHold = false;
        stepFlag = false;
        backWardStep = false;
    }

    /*
     Simulation transformation to step-by-step mode by demand
     */
    public void stepByStepMode()
    {
        gameHold = true;
        stepFlag = true;
        backWardStep = false;
        if (actionCounter == -1) { actionCounter += 1; }
    }

    /*
     Simulation transformation to backward step-by-step mode by demand
     */
    public void stepBackMode()
    {

        gameHold = true;
        stepFlag = false;
        backWardStep = true;

        if (actionCounter >= 0)
        {
            actionCounter -= 1;
        }
    }

    public void initActionCounter()
    {
        actionCounter = 0;
    }

    public void initAgentsActions()
    {
        agentsLastDirections.Clear();
    }

    public void speedUp()    {
        if (simulationSpeed - 4 > 0)        {            simulationSpeed = simulationSpeed - 4;        }    }

    public void speedDown()    {        if (simulationSpeed + 4 < 100)        {            simulationSpeed = simulationSpeed + 4;        }    }





    // private void DrawCharMap(char[,,] map)
    // {
    //     int flagBoxes = 0;
    //     int flagGoals = 0;
    //     int flagWall = 0;
    //     int flagAgents = 0;
    //     int flagFloors = 0;
    //     for (int y = 0; y < map.GetLength(0); y++)
    //     {
    //         for (int x = 0; x < map.GetLength(1); x++)
    //         {
    //             for (int z = 0; z < map.GetLength(2); z++)
    //             {
    //                 GameObject g = null;
    //                 if (map[y, x, z] == 'w')
    //                 {
    //                     g = Instantiate(wall);
    //                     walls[flagWall] = g;
    //                     InitializeWall(walls[flagWall], x, y, z);
    //                     flagWall++;
    //                 }
    //                 if (map[y, x, z] == 'f')
    //                 {

    //                     g = Instantiate(floor);
    //                     floors[flagFloors] = g;
    //                     InitializeFloor(floors[flagFloors], x, y, z);
    //                     flagFloors++;
    //                 }
    //                 if (map[y, x, z] == 'b')
    //                 {
    //                     g = Instantiate(box);
    //                     boxes[flagBoxes] = g;
    //                     InitializeCube(boxes[flagBoxes], x, y, z);
    //                     flagBoxes++;
    //                 }
    //                 if (map[y, x, z] == 'g')
    //                 {
    //                     g = Instantiate(goal);
    //                     goals[flagGoals] = g;
    //                     InitializeCube(goals[flagGoals], x, y, z);
    //                     flagGoals++;
    //                 }
    //                 if (map[y, x, z] == 'h')
    //                 {
    //                     g = Instantiate(agent);
    //                     agents[flagAgents] = g;
    //                     InitializeWorker(agents[flagAgents], x, y, z);
    //                     flagAgents++;
    //                 }
    //                 if (g != null)
    //                     g.transform.parent = maphold.transform;
    //             }
    //         }
    //     }
    //     Deactivate(box);
    //     Deactivate(wall);
    //     Deactivate(floor);
    //     //Deactivate(worker);
    //     Deactivate(goal);
    // }


    // private void AgentMovements(bool isAgent)
    // {

    //         int i = 0;
    //         controller = GetComponent <CharacterController>();
    // 		anim = gameObject.GetComponentInChildren<Animator>();
    //     // anim.SetInteger ("AnimationPar", 0);

    //     if (Input.GetKeyDown(KeyCode.W))
    //     {
    //         anim.SetInteger ("AnimationPar", 1);
    //         foreach (GameObject tbox in boxes)
    //         {
    //             if (agents[i].GetComponent<Transform>().position + new Vector3(-1, 0, 0) == tbox.GetComponent<Transform>().position)
    //             {
    //                 ValidifyMove(tbox, new Vector3(-1, 0, 0));
    //             }
    //         }

    //         // Vector3 newPos = anim.bodyPosition +  new Vector3(-1, 0, 0);
    //         anim.transform.Rotate(anim.transform.right);
    //         // anim.transform.Rotate(0, 90 * turnSpeed * Time.deltaTime, 0);
    //         // anim.transform.Rotate(anim.bodyPosition);
    //         // controller.Move(moveDirection * Time.deltaTime);
    //         // moveDirection.y -= gravity * Time.deltaTime;
    //         ValidifyMove(agents[i], new Vector3(-1, 0, 0));

    //     }
    //     if (Input.GetKeyDown(KeyCode.S))
    //     {
    //         anim.SetInteger ("AnimationPar", 1);
    //         foreach (GameObject tbox in boxes)
    //         {
    //             if (agents[i].GetComponent<Transform>().position + new Vector3(1, 0, 0) == tbox.GetComponent<Transform>().position)
    //                 ValidifyMove(tbox, new Vector3(1, 0, 0));
    //         }
    //         // anim.transform.Rotate(-anim.transform.forward);

    //         ValidifyMove(agents[i], new Vector3(1, 0, 0));
    //     }
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         anim.SetInteger ("AnimationPar", 1);
    //         foreach (GameObject tbox in boxes)
    //         {
    //             if (agents[i].GetComponent<Transform>().position + new Vector3(0, 0, -1) == tbox.GetComponent<Transform>().position)
    //                 ValidifyMove(tbox, new Vector3(0, 0, -1));
    //         }
    //         // anim.transform.Rotate(-anim.transform.right);

    //         ValidifyMove(agents[i], new Vector3(0, 0, -1));
    //     }
    //     if (Input.GetKeyDown(KeyCode.D))
    //     {
    //         anim.SetInteger ("AnimationPar", 1);
    //         foreach (GameObject tbox in boxes)
    //         {
    //             if (agents[i].GetComponent<Transform>().position + new Vector3(0, 0, 1) == tbox.GetComponent<Transform>().position)
    //                 ValidifyMove(tbox, new Vector3(0, 0, 1));
    //         }
    //         // anim.transform.Rotate(anim.transform.right);

    //         ValidifyMove(agents[i], new Vector3(0, 0, 1));
    //     }
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         foreach (GameObject tbox in boxes)
    //         {
    //             if (agents[i].GetComponent<Transform>().position + new Vector3(0, 1, 0) == tbox.GetComponent<Transform>().position)
    //                 ValidifyMove(tbox, new Vector3(0, 1, 0));
    //         }
    //         ValidifyMove(agents[i], new Vector3(0, 1, 0));
    //     }
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         foreach (GameObject tbox in boxes)
    //         {
    //             if (agents[i].GetComponent<Transform>().position + new Vector3(0, -1, 0) == tbox.GetComponent<Transform>().position)
    //                 ValidifyMove(tbox, new Vector3(0, -1, 0));
    //         }
    //         ValidifyMove(agents[i], new Vector3(0, -1, 0));
    //     }
    //     // float turn = Input.GetAxis("Horizontal");
    //     // anim.transform.Rotate(0, 90 * turnSpeed * Time.deltaTime, 0);
    //     // controller.Move(moveDirection * Time.deltaTime);
    //     // moveDirection.y -= gravity * Time.deltaTime;

    // }

}
