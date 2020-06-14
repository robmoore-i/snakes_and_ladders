# Snakes & Ladders

This is a test-driven Snakes & Ladders text game. It worked first time when I
ran it outside of a test :fireworks: :sunglasses:

## Coding Problem

Your task is to create a Snakes & Ladders program, which is played at the
command line, and has the following features:

- When the game starts, the program asks "Who is playing?" and accepts comma
  separated input giving the names of all the players.

- The board is a sequence of discrete spaces on which players can be located.
  Most games use boards with 100 spaces. A player wins the game by reaching the
  last space on the board. 

- The board is covered in some snakes and some ladders.

- Every ladder connects two spaces on the board. One of these spaces will be
  higher, the other will be lower. If a player lands on the lower space of a
  ladder, they climb up it and the result is that they are on the higher space.

- Every snake connects two spaces on the board. One of these spaces will be
  higher, the other will be lower. If a player lands on a higher space of a
  snake, they slide down it, and the result is that they are on the lower space.
  
- Each player starts at the first space on the board.

- The players take turns. On a player's turn, they are interactively prompted
  to roll the dice to determine how far they are moving this turn. The console
  prints out the value on the dice they rolled. They move forward by as many
  positions as are shown on the dice. If they have landed on the significant
  end of either a snake or ladder, this is printed out to console, and they
  then either slide down or climb up, respectively, to arrive at a new position.
  Then their turn ends, and their position is printed out to console.

- Players continue to take turns until a player reaches the last square. When
  a player ends their turn on the finishing square, they are declared the
  winner, and this is announced by printing to the console. Then the game ends.

## Notes on learning a new programming language

- How do I run a program?

- How do I write and execute a unit test?

- How do I apply message-passing polymorphism?

- Which IDE do I use? How do I use it effectively?

- What do I need to know to write effective search-engine queries?
