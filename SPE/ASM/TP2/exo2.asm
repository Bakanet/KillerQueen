VALUE		equ		0
			org		$4
		
Vector_001	dc.l	Main
			org		$500
			
Main		move.b	#VALUE,d1

			tst.b	d1
			bne		next1
			move.l	#200,d0
			bra		quit
			
next1		bmi 	next3
			cmp.b	#$61,d1
			blt		next2
			move.l	#400,d0
			bra		quit
			
next2		move.l	#600,d0
			bra 	quit
			
next3		move.l	#800,d0

quit		illegal
