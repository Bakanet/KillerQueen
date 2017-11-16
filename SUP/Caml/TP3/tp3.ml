(*1.1.1 reverse*)
let reverse n =
  let rec esrever = function
    | (0,x) -> x
    | (n,x) -> esrever (n/10, x*10 + n mod 10)
  in
  esrever (n,0);;

(*1.1.2 prime*)
let prime x =
  if
    x <= 2
  then
    failwith "x isn't over 2"
  else
    let rec optimus x = function
      | 1 -> true
      | n -> x mod n <> 0 && optimus x (n-1)
    in
    optimus x (x/2);;

(*1.2.1 length*)
let rec length = function
  | [] -> 0
  | e::l -> 1 + length l;;

(*1.2.2 count*)
let rec count x = function
  | [] -> 0
  | e::l when e = x -> 1 + count x l
  | _::l -> count x l;;

(*1.2.3 nth*)
let nth n list =
  if n < 0 then
    invalid_arg "n is negative"
  else
    let rec thunderstruck i = function
      | [] -> failwith "n is too big"
      | e::_ when i = 0 -> e
      | _::l -> thunderstruck (i-1) l
    in
    thunderstruck n list;;

(*1.2.4 search_pos*)
let search_pos x list =
  if count x list = 0 then
    failwith "search_pos: not found"
  else
    let rec search x = function
      | [] -> failwith "search_pos: not found"
      | e::_ when x = e -> 0
      | _::l -> 1 + search x l
    in
    search x list;;

(*1.2.5 init_list*)
let rec init_list x e = match x with
  | 0 -> []
  | _ -> e::(init_list (x-1) e);;

(*1.2.6 reverse_list*)
let reverse_list list =
  let rec tsil list l2 = match list with
    | [] -> l2
    | e::l -> tsil l (e::l2)
  in
  tsil list [];;

(*2.1 trajectoire*)
let rec trajectory x = function
  | 0 -> []
  | n -> x::(trajectory (x + reverse x) (n-1));;

(*2.2.1 Goldbach*)
let goldbach n =
  if n mod 2 <> 0 then invalid_arg "Goldbach failed: input must be even"
  else
    let rec bachdore x =
      if
	prime x = true && (n-x) <> 1 then (n-x, x)
      else
	bachdore (x-1)
    in
    bachdore n;;

(*2.2.2 liste de Goldbach*)
let rec goldbach_list a b =
  if
    a > b then []
  else
    (a, goldbach a)::goldbach_list (a+2) b;;

(*2.3.1 decompose*)
let decompose x b =
  let base = length b in
  let rec d_e_c_o_m_p_o_s_e x l = match x with
    | 0 -> []
    | x -> (nth (x mod base) l)::(d_e_c_o_m_p_o_s_e (x/base) l)
  in
  reverse_list(d_e_c_o_m_p_o_s_e x b);;

(*2.3.2 recompose*)
let base_pos x list =
  if count x list = 0 then
    failwith "out of base"
  else
    let rec search x = function
      | [] -> failwith "out of base"
      | e::_ when x = e -> 0
      | _::l -> 1 + search x l
    in
    search x list;;

let recompose l b =
  let base = length b in
  let rec piccolo = function
    | 0 -> 0
    | n -> base * ((base_pos (nth (n-1) l) b) + piccolo (n-1))
  in (piccolo(length l))/base;;

(*2.4.1 insérons*)
let rec insert x = function
  | [] -> x::[]
  | e::l when x >= e -> x::e::l
  | e::l -> e::insert x l;;
