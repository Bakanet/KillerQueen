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