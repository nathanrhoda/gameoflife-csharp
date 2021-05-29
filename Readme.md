
# Game of Life

Implement conway's game of life
https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

video to explain what we trying to achieve:
https://www.youtube.com/watch?v=FdMzngWchDk

Rules
The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead, (or populated and unpopulated, respectively). Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

## Transitions

1. Any live cell with fewer than two live neighbours dies, as if  by underpopulation.
2. Any live cell with two or three live neighbours lives on to the next generation.
3. Any live cell with more than three live neighbours dies, as if by overpopulation.
4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

### Transitions distilled into rules

1. Any live cell with two or three live neighbours survives.
2. Any dead cell with three live neighbours becomes a live cell.
3. All other live cells die in the next generation. Similarly, all other dead cells stay dead.



The first generation is created by applying the above rules simultaneously to every cell in the seed: births and deaths happen simultaneously, and the discrete moment at which this happens is sometimes called a tick (in other words, each generation is a pure function of the one before).

The rules continue to be applied repeatedly to create further generations.

### Hints

Work off the assumption that this is a 9 by 9 grid