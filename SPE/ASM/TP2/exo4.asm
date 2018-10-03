			org		$4
Vector_001	dc.l	Main

			org		$500
		
Main		movea.l	#STRING,a0

StrLen		clr.l	d0

loop		tst.b	(a0)+
			beq		quit
			addq.l	#1,d0
			bra 	loop
			
quit		illegal

			org 	$550
			
STRING		dc.b	"Cette chaine comporte 36 caracteres.",0
