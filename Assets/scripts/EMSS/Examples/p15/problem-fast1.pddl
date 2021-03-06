(define (problem elevators-sequencedstrips-p16_16_1) (:domain elevators-sequencedstrips)
(:objects
	n12 - count
	n13 - count
	n10 - count
	n16 - count
	n14 - count
	n15 - count
	p10 - passenger
	p11 - passenger
	p12 - passenger
	p13 - passenger
	p14 - passenger
	p15 - passenger
	p2 - passenger
	p3 - passenger
	p0 - passenger
	p1 - passenger
	p6 - passenger
	p7 - passenger
	p4 - passenger
	p5 - passenger
	p8 - passenger
	p9 - passenger
	n8 - count
	n0 - count
	n1 - count
	n2 - count
	n3 - count
	n4 - count
	n5 - count

	(:private
		fast1 - fast-elevator
	)
)
(:init
	(next n0 n1)
	(next n1 n2)
	(next n2 n3)
	(next n3 n4)
	(next n4 n5)
	(next n12 n13)
	(next n13 n14)
	(next n14 n15)
	(next n15 n16)
	(above n0 n1)
	(above n0 n2)
	(above n0 n3)
	(above n0 n4)
	(above n0 n5)
	(above n0 n8)
	(above n0 n10)
	(above n0 n12)
	(above n0 n13)
	(above n0 n14)
	(above n0 n15)
	(above n0 n16)
	(above n1 n2)
	(above n1 n3)
	(above n1 n4)
	(above n1 n5)
	(above n1 n8)
	(above n1 n10)
	(above n1 n12)
	(above n1 n13)
	(above n1 n14)
	(above n1 n15)
	(above n1 n16)
	(above n2 n3)
	(above n2 n4)
	(above n2 n5)
	(above n2 n8)
	(above n2 n10)
	(above n2 n12)
	(above n2 n13)
	(above n2 n14)
	(above n2 n15)
	(above n2 n16)
	(above n3 n4)
	(above n3 n5)
	(above n3 n8)
	(above n3 n10)
	(above n3 n12)
	(above n3 n13)
	(above n3 n14)
	(above n3 n15)
	(above n3 n16)
	(above n4 n5)
	(above n4 n8)
	(above n4 n10)
	(above n4 n12)
	(above n4 n13)
	(above n4 n14)
	(above n4 n15)
	(above n4 n16)
	(above n5 n8)
	(above n5 n10)
	(above n5 n12)
	(above n5 n13)
	(above n5 n14)
	(above n5 n15)
	(above n5 n16)
	(above n8 n10)
	(above n8 n12)
	(above n8 n13)
	(above n8 n14)
	(above n8 n15)
	(above n8 n16)
	(above n10 n12)
	(above n10 n13)
	(above n10 n14)
	(above n10 n15)
	(above n10 n16)
	(above n12 n13)
	(above n12 n14)
	(above n12 n15)
	(above n12 n16)
	(above n13 n14)
	(above n13 n15)
	(above n13 n16)
	(above n14 n15)
	(above n14 n16)
	(above n15 n16)
	(lift-at fast1 n8)
	(passengers fast1 n0)
	(can-hold fast1 n1)
	(can-hold fast1 n2)
	(can-hold fast1 n3)
	(can-hold fast1 n4)
	(reachable-floor fast1 n0)
	(reachable-floor fast1 n4)
	(reachable-floor fast1 n8)
	(reachable-floor fast1 n12)
	(reachable-floor fast1 n16)
	(passenger-at p0 n5)
	(passenger-at p1 n4)
	(passenger-at p2 n5)
	(passenger-at p3 n6)
	(passenger-at p4 n6)
	(passenger-at p5 n3)
	(passenger-at p6 n5)
	(passenger-at p7 n15)
	(passenger-at p8 n7)
	(passenger-at p9 n0)
	(passenger-at p10 n9)
	(passenger-at p11 n12)
	(passenger-at p12 n2)
	(passenger-at p13 n1)
	(passenger-at p14 n6)
	(passenger-at p15 n0)
	(= (travel-slow n0 n1) 6) 
	(= (travel-slow n0 n2) 7) 
	(= (travel-slow n0 n3) 8) 
	(= (travel-slow n0 n4) 9) 
	(= (travel-slow n0 n5) 10) 
	(= (travel-slow n0 n8) 13) 
	(= (travel-slow n1 n2) 6) 
	(= (travel-slow n1 n3) 7) 
	(= (travel-slow n1 n4) 8) 
	(= (travel-slow n1 n5) 9) 
	(= (travel-slow n1 n8) 12) 
	(= (travel-slow n2 n3) 6) 
	(= (travel-slow n2 n4) 7) 
	(= (travel-slow n2 n5) 8) 
	(= (travel-slow n2 n8) 11) 
	(= (travel-slow n3 n4) 6) 
	(= (travel-slow n3 n5) 7) 
	(= (travel-slow n3 n8) 10) 
	(= (travel-slow n4 n5) 6) 
	(= (travel-slow n4 n8) 9) 
	(= (travel-slow n5 n8) 8) 
	(= (travel-slow n8 n10) 7) 
	(= (travel-slow n8 n12) 9) 
	(= (travel-slow n8 n13) 10) 
	(= (travel-slow n8 n14) 11) 
	(= (travel-slow n8 n15) 12) 
	(= (travel-slow n8 n16) 13) 
	(= (travel-slow n10 n12) 7) 
	(= (travel-slow n10 n13) 8) 
	(= (travel-slow n10 n14) 9) 
	(= (travel-slow n10 n15) 10) 
	(= (travel-slow n10 n16) 11) 
	(= (travel-slow n12 n13) 6) 
	(= (travel-slow n12 n14) 7) 
	(= (travel-slow n12 n15) 8) 
	(= (travel-slow n12 n16) 9) 
	(= (travel-slow n13 n14) 6) 
	(= (travel-slow n13 n15) 7) 
	(= (travel-slow n13 n16) 8) 
	(= (travel-slow n14 n15) 6) 
	(= (travel-slow n14 n16) 7) 
	(= (travel-slow n15 n16) 6) 
	(= (travel-fast n0 n4) 13) 
	(= (travel-fast n0 n8) 25) 
	(= (travel-fast n0 n12) 37) 
	(= (travel-fast n0 n16) 49) 
	(= (travel-fast n4 n8) 13) 
	(= (travel-fast n4 n12) 25) 
	(= (travel-fast n4 n16) 37) 
	(= (travel-fast n8 n12) 13) 
	(= (travel-fast n8 n16) 25) 
	(= (travel-fast n12 n16) 13) 
	(= (total-cost) 0) 
)
(:goal
	(and
		(passenger-at p0 n13)
		(passenger-at p1 n10)
		(passenger-at p2 n2)
		(passenger-at p3 n16)
		(passenger-at p4 n16)
		(passenger-at p5 n16)
		(passenger-at p6 n12)
		(passenger-at p7 n8)
		(passenger-at p8 n5)
		(passenger-at p9 n3)
		(passenger-at p10 n15)
		(passenger-at p11 n8)
		(passenger-at p12 n1)
		(passenger-at p13 n14)
		(passenger-at p14 n4)
		(passenger-at p15 n14)
	)
)
(:metric minimize (total-cost))
)