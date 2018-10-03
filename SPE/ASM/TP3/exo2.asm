			org		$4
			
Vector_001	dc.l	Main
			org		$500
			
Main		movea.l	#String1,a0
			jsr		StrLen
			
			movea.l	#String2,a0
			jsr		StrLen
			
			illegal
			
StrLen		move.l	a0,-(a7)
			clr.l	d0

\loop		tst.b	(a0)+
			beq		\quit
			
			addq.l	#1,d0
			bra		\loop
			
\quit		movea.l	(a7)+,a0
			rts
			
String1		dc.b	"Cette chaine comporte 36 caracteres.",0
String2		dc.b	"Celle-ci en comporte 24.",0
