
# The Challenge
Ash is picking up Pokemons in a world that consists of an infinite two-dimensional grid of houses. In every house there is exactly one Pokemon.<br/>
Ash starts by catching the Pokemon that it is in the house where he starts. Next, he moves to the next house immediately to the north, south, 
east or west of where he is and picks up the Pokemon that is there, and so on.<br/>
Note: if he passes by a house where he has already passed (and therefore where he has already caught a Pokemon), no longer there is a Pokemon for him to catch!<br/>

# What's the goal?
The goal is to create a Pokemon world full of pokemons where Ash will receive an input of instructions from the user to path.<br/> 
After executing that path, the user will get an output of how many Pokemons Ash caught.



### Things I had to consider:
- A bidimentional infite table where each square has a Pokemon
- Ashe catches the pokemon from place he starts
- He cannot cath a pokemon from a square he has catched already
- The input comes in as NESW(North, East, South, West)

**The solution is a simple console app**
![PokemonCathThemAll](https://user-images.githubusercontent.com/86933138/135474974-1c847178-3504-486a-aedc-29a3cf851574.png)

