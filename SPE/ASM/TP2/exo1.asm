			org	$4

Vector_001	dc.l	Main
			org $500
Main		clr.l	d1
			move.l	#$80000007,d0
loop1		addq.l	#1,d1
			subq.l 	#1,d0
			bne		loop1

			clr.l	d2
			move.l	#$fe2310,d0
loop2		addq.l	#1,d2
			subq.l	#2,d0
			bne 	loop2

			clr.l 	d3
			moveq.l	#125,d0
loop3		addq.l	#1,d3
			dbra	d0,loop3
			
			clr.l	d4
			moveq.l	#10,d0
loop4		addq.l	#1,d4
			addq.l	#1,d0
			cmpi.l	#30,d0
			bne loop4
			
			illegal
