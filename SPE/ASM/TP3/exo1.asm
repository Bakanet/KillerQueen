			org		$4
			
Vector_001	dc.l	Main

			org		$500
			
Main		move.l	#-4,d0
			jsr		Abs
			
			move.l	#-32500,d0
			jsr 	Abs
			
			illegal
			
Abs			tst.l	d0
			bpl		\quit
			
			neg.l	d0
			
\quit		rts
