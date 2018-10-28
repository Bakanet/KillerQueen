org			$4

vector_001	dc.l	Main

			org		$500
			
Main		movea.l	#String1,a0
			jsr		SpaceCount
			
			movea.l	#String2,a0
			jsr		SpaceCount
			
			illegal
			
SpaceCount	movem.l	d1/a0,-(a7)

			clr.r	d0
			
\loop		move.b	(a0)+,d1
			beq		\quit
			
			cmp.b	#' ',d1
			bne		\loop
			
			addq.l	#1,d0
			bra		\loop
			
			addq.l	#1,d0
			bra 	\loop
			
\quit		movem.l	(a7)+,d1/a0
			rts
			
String1		dc.b	"Cette chaine comporte 4 espaces."
String2		dc.b	"Celle-ci en comporte 3."
