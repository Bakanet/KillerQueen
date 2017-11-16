(************************************************************)
(*                     Game of life                         *)
(************************************************************)

(* graphics *)

#load "graphics.cma" ;
open Graphics ;;

let open_window size =
  open_graph(" " ^ string_of_int size ^ "x" ^ string_of_int (size+20));;

let grey = rgb 127 127 127 ;;

let cell_color = function
  | 0 -> white
  | _ -> black ;;

let cell_size = 10 ;;

(* original game of life definitions *)

let new_cell = 1 ;;

let empty = 0 ;;

let is_alive cell = cell <> empty ;;


(*******************   FROM TP 3 *********************)
(*   insert here needed simple functions on lists    *)

let rec length = function
  | [] -> 0
  | e::l -> 1 + length l;;

let rec init_list x e = match x with
  | 0 -> []
  | _ -> e::(init_list (x-1) e);;

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

(*******************   Toolbox *********************)
(*             list list functions                 *)

let gen_board (l,c) x =
    init_list l (init_list c x);;

let get_cell (x,y) board =
  (nth y (nth x board));;
  
let put_cell value (x,y) board =
  let rec insert n c v = function
    | [] -> []
    | _::l when c = n -> insert n (c+1) v (v::l)
    | e::l -> e::(insert n (c+1) v l)
  in
  insert y 0 (insert x 0 value (nth y board)) board;;
  
let count_neighbours (x,y) board (l,c) =
  let rec brotherhood (a,b) = function
    | [] | []::[] when is_alive (get_cell (x,y) board) -> -1
    | [] | []::[]-> 0
    | []::l2 -> brotherhood ((a+1),0) l2
    | (e::l1)::l2 when a >= 0 && a <= (l-1) && b >=0 && b <= (c-1) && b >= y-1 && b <= y+1 && a >= x-1 && a <= x+1 && is_alive e -> 1 + brotherhood (a,(b+1)) (l1::l2)
    | (e::l1)::l2 -> brotherhood (a,(b+1)) (l1::l2)
  in
  brotherhood (0,0) board;;


(************************************************************)
(*                  graphics                                *)
(*        from the board to the graphic window              *)

let draw_cell (x,y) size color =
  set_color color ;
  fill_rect (x+1) (y+1) size size ;
  set_color grey ;
  draw_rect (x+1) (y+1) size size ;;

let draw_board board size =
  clear_graph();
  let rec build_elem (x,y) = function
    | [] -> ()
    | e::l -> draw_cell (x,y) size (cell_color e) ; build_elem (x, (y + size)) l

  in
  
  let rec recup_list (x,y) = function
    | [] -> ()
    | e::l -> build_elem (x,y) e ; recup_list ((x + size), y) l

  in

  recup_list (0,0) board;;

(************************************************************)
(*                     Game of life                         *)
(************************************************************)

let rules0 cell near =
  if cell = 0 then
    if near = 3 then new_cell
    else cell
      
  else
    if near = 2 || near = 3 then cell
    else empty;;

let seed_life board size nb_cell =
  let rec somalien board = function
    | 0 -> board
    | n -> somalien (put_cell new_cell ((Random.int size),(Random.int size)) board) (n-1)
  in
  somalien board nb_cell;;

let new_board size nb_cell =
  seed_life (gen_board (size, size) empty) size nb_cell;;

let next_generation board =
  let size = length board in
  
  let rec next_gen (x,y) = function
    | [] -> []
    | e::l -> (rules0 (get_cell (x,y) board) (count_neighbours (x,y) board (size, size)))::(next_gen (x, (y+1)) l)

  in
  
  let rec recup_list (x,y) = function
    | [] -> []
    | e::l -> (next_gen (x,y) e)::(recup_list ((x+1),y) l)
      
  in
  recup_list (0,0) board;;
  
let rec game board n = match n with
    | 0 -> ()
    | n -> draw_board board cell_size ; game (next_generation board) (n-1);;

let new_game size nb_cell n =
  let board = new_board size nb_cell in
  open_window (length board * size + 40) ;
  game board n;;
