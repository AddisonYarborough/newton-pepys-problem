# newton-pepys-problem
A console application that tests a famous dice probability problem known as the **Newton–Pepys Problem**.

## The Problem

#### Would it be more likely to roll one six in 6 dice, two sixes in 12 dice, or three sixes in 18 dice?

_For purposes of this test, we will assume that groups that land on more than 1 six per set are also considered "successful", although the original problem posed to Newton and Pepys by a school teacher named John Smith was ambiguous as to whether throwing more than 1 six per set of six dice should be considered "successful"._

#### The Test
1. Throw **6** dice counting how many land on the **"6"** face
2. Throw **12** dice and count how many land on the **"6"** face
3. Throw **18** dice and count how many land on the **"6"** face

Surprisingly, the probability is different for each of these.

- 6 dice = 66.51% chance of at least one six
- 12 dice = 61.87% chance of at least two sixes
- 18 dice = 59.73% chance of at least 3 sixes

In my approach, I throw all throws in sets of 6, rather than 12/18/etc. at the time.
This ends in the same result as if we were to do it the other way.

For more history and a mathmatical explanation, visit [the wikipedia page](https://en.wikipedia.org/wiki/Newton%E2%80%93Pepys_problem#:~:text=The%20Newton%E2%80%93Pepys%20problem%20is,school%20teacher%20named%20John%20Smith.) for this problem.

Running this test gives these results:

#### Rolled all sets 1,000,000 times

- Percentage of sets containing 1 throw that had at least 1 die landing on 6: 66.5682%
- Percentage of sets containing 2 throws that had at least 2 die landing on 6: 61.9443%
- Percentage of sets containing 3 throws that had at least 3 die landing on 6: 59.7407%

