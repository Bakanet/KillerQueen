			org		$4
			
Vector_001	dc.l	Main

			org		$500
			
Main		move.l	#-1,d0

Abs			tst.l	d0
			bpl		quit
			neg.l	d0
			
quit		illegal
