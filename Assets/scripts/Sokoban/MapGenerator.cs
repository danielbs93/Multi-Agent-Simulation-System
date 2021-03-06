﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator {

    //Private Fields
    private char[,,] current_map;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public char[,,] GenerateMap(int mapNumber)
    {
        if (mapNumber == 1)
        {
            current_map = getMapOneGoal();
        }

        if (mapNumber == 2)
        {
            current_map = getMapMulitpleGoals();
        }

        return current_map;
    }

    private char[,,] getMapOneGoal()
    {
        return new char[3, 20, 20] {
        {
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'}
        },
        {
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'g', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', 'h', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', 'b', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'}
        },
        {
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'}
        },
    };
    }

    private char[,,] getMapMulitpleGoals()
    {
        return new char[3, 20, 20] {
        {
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'}
        },
        {
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'g', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', 'b', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'b', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'g', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'b', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', 'h', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'g', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'}
        },
        {
            {'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w','w', 'w', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'},
            {'w', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w'}
        },
    };
    }
}
