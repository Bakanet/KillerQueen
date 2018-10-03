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

let square2

let rec triangle n str =
  if n = 0 then ()
  else
    triangle (n-1) str; print_string(build_line n str); print_newline();;
