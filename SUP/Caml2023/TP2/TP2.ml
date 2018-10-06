let rec build_line n str =
  if n = 0 then str
  else
    str ^ build_line (n-1) str;;

let square n str =
  let rec bn n m str =
    if n = 0 then ()
    else
      bn (n-1) m str; print_string(build_line m str); print_newline()
  in
  bn n n str;;
	
let square2 n (str,str2) =
  let rec build_line2 n a (str,str2) =
    if n = 0 then
      if a mod 2 = 0 then str else str2
    else
      if (n + a) mod 2 = 0 then str ^ build_line2 (n-1) a (str,str2)
      else
	str2 ^ build_line2 (n-1) a (str,str2)
  in
  let rec square_build n m a (str,str2) =
    if n = 0 then ()
    else
      (square_build (n-1) m (a+1) (str,str2)); print_string(build_line2 m a (str,str2)); print_newline()
  in
  square_build n (n*2) 0 (str,str2)

let rec triangle n str =
  if n = 0 then ()
  else
    triangle (n-1) str; print_string(build_line n str); print_newline();;

#load "graphics.cma";;
open Graphics;;

let draw_line (x,y) (z,t) =
  moveto x y;
  lineto z t;;

let rec mountain n (x,y) (z,t) =
  if n = 0 then draw_line (x,y) (z,t)
  else
    let m = (x+z) / 2 in let h = (y+t)/2 + Random.int(10*n) in
			 mountain (n-1) (x,y) (m,h); mountain (n-1) (m,h) (z,t);;

let rec dragon n (x,y) (z,t) =
  if n = 0 then draw_line (x,y) (z,t)
  else
    let u = ((x+z)/2) + ((t-y)/2) in let v = (y+t)/2 - (z-x)/2 in
				     dragon (n-1) (x,y) (u,v); dragon (n-1) (z,t) (u,v);;
let rec draw_sponge (x,y) n =
    if n <= 1 then fill_rect x y n n
    else
      draw_sponge (x,y) (n/3); draw_sponge (x + n/3, y) (n/3);
  draw_sponge (x + 2*n/3, y) (n/3); draw_sponge (x, y - n/3) (n/3);
  draw_sponge (x + 2*n/3, y - n/3) (n/3); draw_sponge (x, y - 2*n/3) (n/3);
  draw_sponge (x + n/3, y - 2*n/3) (n/3); draw_sponge (x + 2*n/3, y - 2*n/3) (n/3);;
(*doen't work -> stack overflow ??*)
