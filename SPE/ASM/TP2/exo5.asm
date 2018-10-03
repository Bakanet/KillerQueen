			org 	$4

Vector_001	dc.l	Main
			
			org		$500
			
Main		movea.l	#STRING,a0

SpaceCount	move.w 	#32,d1
			clr.l	d0

loop		tst.b	(a0)
			beq		quit
			cmp.b	(a0)+,d1
			bne		jump	
			addq.l 	#1,d0
jump		bra		loop

quit		illegal
			
			org 	$550
			
STRING		dc.b	"Cette chaine comporte 4 espaces.",0
