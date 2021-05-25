(define (problem elevators-sequencedstrips-p16_18_1) (:domain elevators-sequencedstrips)
(:objects
	n12 - count
	n10 - count
	n11 - count
	n16 - count
	n15 - count
	p10 - passenger
	p11 - passenger
	p12 - passenger
	p13 - passenger
	p14 - passenger
	p15 - passenger
	p16 - passenger
	p17 - passenger
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
	n6 - count

	(:private
		fast0 - fast-elevator
	)
)
(:init
	(next n0 n1)
	(next n1 n2)
	(next n2 n3)
	(next n3 n4)
	(next n4 n5)
	(next n5 n6)
	(next n10 n11)
	(next n11 n12)
	(next n15 n16)
	(above n0 n1)
	(above n0 n2)
	(above n0 n3)
	(above n0 n4)
	(above n0 n5)
	(above n0 n6)
	(above n0 n8)
	(above n0 n10)
	(above n0 n11)
	(above n0 n12)
	(above n0 n15)
	(above n0 n16)
	(above n1 n2)
	(above n1 n3)
	(above n1 n4)
	(above n1 n5)
	(above n1 n6)
	(above n1 n8)
	(above n1 n10)
	(above n1 n11)
	(above n1 n12)
	(above n1 n15)
	(above n1 n16)
	(above n2 n3)
	(above n2 n4)
	(above n2 n5)
	(above n2 n6)
	(above n2 n8)
	(above n2 n10)
	(above n2 n11)
	(above n2 n12)
	(above n2 n15)
	(above n2 n16)
	(above n3 n4)
	(above n3 n5)
	(above n3 n6)
	(above n3 n8)
	(above n3 n10)
	(above n3 n11)
	(above n3 n12)
	(above n3 n15)
	(above n3 n16)
	(above n4 n5)
	(above n4 n6)
	(above n4 n8)
	(above n4 n10)
	(above n4 n11)
	(above n4 n12)
	(above n4 n15)
	(above n4 n16)
	(above n5 n6)
	(above n5 n8)
	(above n5 n10)
	(above n5 n11)
	(above n5 n12)
	(above n5 n15)
	(above n5 n16)
	(above n6 n8)
	(above n6 n10)
	(above n6 n11)
	(above n6 n12)
	(above n6 n15)
	(above n6 n16)
	(above n8 n10)
	(above n8 n11)
	(above n8 n12)
	(above n8 n15)
	(above n8 n16)
	(above n10 n11)
	(above n10 n12)
	(above n10 n15)
	(above n10 n16)
	(above n11 n12)
	(above n11 n15)
	(above n11 n16)
	(above n12 n15)
	(above n12 n16)
	(above n15 n16)
	(lift-at fast0 n16)
	(passengers fast0 n0)
	(can-hold fast0 n1)
	(can-hold fast0 n2)
	(can-hold fast0 n3)
	(can-hold fast0 n4)
	(reachable-floor fast0 n0)
	(reachable-floor fast0 n4)
	(reachable-floor fast0 n8)
	(reachable-floor fast0 n12)
	(reachable-floor fast0 n16)
	(passenger-at p0 n12)
	(passenger-at p1 n10)
	(passenger-at p2 n11)
	(passenger-at p3 n13)
	(passenger-at p4 n5)
	(passenger-at p5 n2)
	(passenger-at p6 n4)
	(passenger-at p7 n4)
	(passenger-at p8 n15)
	(passenger-at p9 n13)
	(passenger-at p10 n16)
	(passenger-at p11 n12)
	(passenger-at p12 n0)
	(passenger-at p13 n1)
	(passenger-at p14 n3)
	(passenger-at p15 n16)
	(passenger-at p16 n5)
	(passenger-at p17 n0)
	(= (travel-slow n0 n1) 6) 
	(= (travel-slow n0 n2) 7) 
	(= (travel-slow n0 n3) 8) 
	(= (travel-slow n0 n4) 9) 
	(= (travel-slow n0 n5) 10) 
	(= (travel-slow n0 n6) 11) 
	(= (travel-slow n0 n8) 13) 
	(= (travel-slow n1 n2) 6) 
	(= (travel-slow n1 n3) 7) 
	(= (travel-slow n1 n4) 8) 
	(= (travel-slow n1 n5) 9) 
	(= (travel-slow n1 n6) 10) 
	(= (travel-slow n1 n8) 12) 
	(= (travel-slow n2 n3) 6) 
	(= (travel-slow n2 n4) 7) 
	(= (travel-slow n2 n5) 8) 
	(= (travel-slow n2 n6) 9) 
	(= (travel-slow n2 n8) 11) 
	(= (travel-slow n3 n4) 6) 
	(= (travel-slow n3 n5) 7) 
	(= (travel-slow n3 n6) 8) 
	(= (travel-slow n3 n8) 10) 
	(= (travel-slow n4 n5) 6) 
	(= (travel-slow n4 n6) 7) 
	(= (travel-slow n4 n8) 9) 
	(= (travel-slow n5 n6) 6) 
	(= (travel-slow n5 n8) 8) 
	(= (travel-slow n6 n8) 7) 
	(= (travel-slow n8 n10) 7) 
	(= (travel-slow n8 n11) 8) 
	(= (travel-slow n8 n12) 9) 
	(= (travel-slow n8 n15) 12) 
	(= (travel-slow n8 n16) 13) 
	(= (travel-slow n10 n11) 6) 
	(= (travel-slow n10 n12) 7) 
	(= (travel-slow n10 n15) 10) 
	(= (travel-slow n10 n16) 11) 
	(= (travel-slow n11 n12) 6) 
	(= (travel-slow n11 n15) 9) 
	(= (travel-slow n11 n16) 10) 
	(= (travel-slow n12 n15) 8) 
	(= (travel-slow n12 n16) 9) 
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
		(passenger-at p0 n11)
		(passenger-at p1 n4)
		(passenger-at p2 n15)
		(passenger-at p3 n8)
		(passenger-at p4 n0)
		(passenger-at p5 n5)
		(passenger-at p6 n10)
		(passenger-at p7 n3)
		(passenger-at p8 n10)
		(passenger-at p9 n16)
		(passenger-at p10 n5)
		(passenger-at p11 n3)
		(passenger-at p12 n3)
		(passenger-at p13 n6)
		(passenger-at p14 n6)
		(passenger-at p15 n5)
		(passenger-at p16 n2)
		(passenger-at p17 n15)
	)
)
(:metric minimize (total-cost))
)