			org		$4
			
Vector_001	dc.l	Main

			org		$500
			
Main		movea.l	#STRING,a0

LowerCount	clr.l	d0

loop		move.b	(a0)+,d1
			beq		quit
			
			cmp.b	#'a',d1
			blo		loop
			
			cmp.b	#'z',d1
			bhi		loop
			
			addq.l	#1,d0
			bra 	loop


quit		illegal

			org		$550
			
STRING		dc.b	"Cette chaine comporte 28 minuscules.",0
