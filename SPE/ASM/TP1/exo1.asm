	org $4
Vector_001 dc.l Main
	org $500
Main	move.b #$41,d0
		move.w #65535,d1
		move.l #-5,d2
