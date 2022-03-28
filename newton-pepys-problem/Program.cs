internal static class NewtonPepysProblem {

    /// <summary>
    /// The number of faces on each die.
    /// </summary>
    private const int _FACES_PER_DIE = 6;

    /// <summary>
    /// The number of dice rolled each time a throw happens.
    /// </summary>
    private const int _DICE_PER_THROW = 6;

    /// <summary>
    /// The face value we are looking for at least one of to consider a throw a "success".
    /// </summary>
    private const int _TARGET_DIE_VALUE = 6;

    /// <summary>
    /// The number of attempts for all throws.
    /// </summary>
    /// <remarks>
    /// Use a higher number for better statistical accuracy.
    /// </remarks>
    private const int _ATTEMPT_COUNT = 1000000;

    /// <summary>
    /// A random number generator, created only once per program.
    /// </summary>
    private static readonly Random _rng = new();

    /// <summary>
    /// A map of:
    /// Key: The number of throws per "set".
    /// Value: The number times a throw resulted in at least one target value per throw.
    /// </summary>
    private static readonly Dictionary<int, int> _setCountToRolledSixesMap = new() {
        { 1, 0 },
        { 2, 0 },
        { 3, 0 },
    };

    private static void Main() {
        PerformAllSetThrows();
        LogResults();
    }

    private static void PerformAllSetThrows() {
        for (int attempts = 0; attempts < _ATTEMPT_COUNT; attempts++) {
            PerformSetOfThrows(throwsPerSet: 1);
            PerformSetOfThrows(throwsPerSet: 2);
            PerformSetOfThrows(throwsPerSet: 3);
        }
    }

    private static void LogResults() {
        Console.WriteLine($"Rolled all sets {_ATTEMPT_COUNT:n0} time{(_ATTEMPT_COUNT > 1 ? "s" : string.Empty)}\n");

        for (int i = 1; i < 4; i++) {
            Console.WriteLine($"Percentage of sets containing {i} throw{((i > 1) ? "s" : string.Empty)} that had at least {i} die landing on {_TARGET_DIE_VALUE}:" +
                              $" {(float)_setCountToRolledSixesMap[i] / _ATTEMPT_COUNT * 100}%");
        }
    }

    /// <summary>
    /// Perform a set of throws.
    /// If the cumulative number of <see cref="_TARGET_DIE_VALUE"/> found in all throws meets or exceeds
    /// the number of <see cref="throwsPerSet"/>, the corresponding <see cref="_setCountToRolledSixesMap"/> value will be incremented.
    /// </summary>
    private static void PerformSetOfThrows(int throwsPerSet) {
        int totalTargetValuesInAllSets = 0;

        // For each number of sets to roll..
        for (int setIndex = 0; setIndex < throwsPerSet; setIndex++) {
            // Roll the set and store the number of sixes rolled
            int rolledTargetValues = GetNumberOfTargetValuesInDiceThrow(_DICE_PER_THROW);

            totalTargetValuesInAllSets += rolledTargetValues;
        }

        if (totalTargetValuesInAllSets >= throwsPerSet) {
            // Increment the count for that set
            _setCountToRolledSixesMap[throwsPerSet]++;
        }
    }

    /// <summary>
    /// Perform a dice throw and return how many of the dice landed on <see cref="_TARGET_DIE_VALUE"/>.
    /// </summary>
    private static int GetNumberOfTargetValuesInDiceThrow(int dicePerThrow) {
        // The number of die this throw that landed on the target value
        int targetValuesRolled = 0;

        // Throw n dice and return the number of dice that landed on the target die value
        for (int die = 0; die < dicePerThrow; die++) {
            // The limit for the RNG is the max value +1 since RNG is exclusive
            const int limit = _FACES_PER_DIE + 1;

            if (_rng.Next(1, limit) == _TARGET_DIE_VALUE) {
                targetValuesRolled++;
            }
        }

        return targetValuesRolled;
    }
}
