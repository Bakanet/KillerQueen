(************************************************************)
(*                 Higher Order Functions                   *)
(************************************************************)

(*****************     Toolbox   *******************)
(*                 Char and String                 *)

let char_type c =
  let c = int_of_char c in
  if c >= 65 && c <= 90 then
    "upper"
  else if c >= 97 && c <= 122 then
    "lower"
  else
    "other";;

let uppercase c =
  if char_type c = "lower" then
    char_of_int (int_of_char c - 32)
  else c;;

let lowercase c =
  if char_type c = "upper" then
    char_of_int (int_of_char c + 32)
  else c;;

let swap_alpha c =
  let c2 = int_of_char c in
  if char_type c = "upper" then
    char_of_int (155 - c2)
  else if char_type c = "lower" then
    char_of_int (219 - c2)
  else
    c;;

let rotn n c =
  let c2 = int_of_char c in
  if char_type c = "upper" then
    if c2 + n > 90 then
      char_of_int (c2 + (n mod 26) - 26)
    else
      if c2 + n < 65 then
	char_of_int (c2 - ((-n) mod 26) + 26)
      else char_of_int (c2 + n)

  else if char_type c = "lower" then
    if c2 + n > 122 then
      char_of_int (c2 + (n mod 26) - 26)
    else
      if c2 + n < 97 then
	char_of_int (c2 - ((-n) mod 26) + 26)
      else char_of_int (c2 + n)
  else
    c;;

let rot13 = rotn 13 ;;

let rec string_of_list = function
  | [] -> ""
  | e::l -> (Char.escaped e)^(string_of_list l);;

let list_of_string str =
  let rec sylphe_sarl n =
    let length = String.length str - 1 in
    if n = length then
      (str.[length])::[]
    else
      (str.[n])::(sylphe_sarl (n+1))
  in
  sylphe_sarl 0;;

let rec map f = function
  | [] -> []
  | e::l -> (f e)::(map f l);;

let uppercase_list list =
  map uppercase list;;

let lowercase_list list =
  map lowercase list;;

let rec iter f = function
  | [] -> ()
  | e::l -> f e ; iter f l;;

let rec map2 f list_a list_b =  match (list_a,list_b) with
    | ([],[]) -> []
    | ([],_) | (_,[]) -> failwith "map2: different size"
    | (p::k, m::n) -> (f p m)::(map2 f k n);;
  
(*                   Higher Order                  *)


(*****************     Cipher    *******************)
(*                  Ceasar Cipher                  *)

let caesar_encode n s =
  string_of_list (map (rotn n) (list_of_string s));;

let caesar_decode n s =
  string_of_list (map (rotn (-n)) (list_of_string s));;

	
(*                 Vigenere Cipher                 *)

let char_encode_vigen c ckey =
  if char_type ckey = "upper" then
    rotn (int_of_char ckey - 65) c
  else if char_type ckey = "lower" then
    rotn (int_of_char ckey - 97) c
  else c;;

let char_decode_vigen c ckey =
  if char_type ckey = "upper" then
    rotn (-(int_of_char ckey - 65)) c
  else if char_type ckey = "lower" then
    rotn (-(int_of_char ckey - 97)) c
  else c;;

let gen_key_list list key =
  let n = key in
  let rec genesect (b,k) = match (b,k) with
    | ([],_) -> []
    | (b,[]) -> genesect (b,n)
    | (e::l,f::l2) ->
      if char_type e <> "other" then
	f::genesect (l,l2)
      else
	e::genesect (l,(f::l2))
  in
  genesect (list,key);;

let vigenere f key code =
  let keyzzz = gen_key_list (list_of_string code) (list_of_string key) in
  let codex = list_of_string code in
  string_of_list (map2 f codex keyzzz);;

(*****************  Build House  *******************)

let sand = ['B' ; 'b' ; 'L' ; 'r' ; 'B'; 'B' ; '\n'];;
let water = ['y' ; 'o' ; 'y' ; 'y' ; 'i'; 'y'; '\n'];;
let brick = ['y' ; 's' ; 's' ; 's' ; 's'; 'e'; '\n'];;
let wood = ['h' ; 'r' ; 'w' ; 'w' ; 'r'; 'h'; '\n'];;
let coca = ['s' ; 'l' ; 'r' ; 'x' ; 'l'; 's'; '\n'];;

let house = [sand ; water ; brick ; wood ; coca];;

let workers = [lowercase ; swap_alpha ; rot13 ; rotn 5 ; rotn 20];;

let rec chain f_list char_list = match (f_list, char_list) with
  | ([],_) | (_,[]) -> []
  | (e::l, e2::l2) -> (map e e2)::(chain l l2);;
  
let fundations = chain workers house;;

let char_material = function
  | 'm' -> print_char '|'
  | 'f' -> print_char '_'
  | 'l' -> print_char '/'
  | 'r' -> print_char '\\'
  | 'w' -> print_char '+'
  | 'b' -> print_char ' '
  | '\n'-> print_char '\n'
  | n   -> print_char n;;

let rec print_house f house = match house with
  | [] -> ()
  | e::l -> iter f e ; print_house f l;;
