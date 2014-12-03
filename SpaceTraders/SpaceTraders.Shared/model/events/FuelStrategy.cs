using System;


/**
 * Strategy for handling fuel events.
 *
 * @author ngraves3
 *
 */
public class FuelStrategy : EventStrategy {

    /**
     * Phrases for losing fuel.
     */
    private String[] losePhrases = {"%d units of your fuel leaked out!",
            "A thief stole %d units of fuel!"}; //i'm all out of ideas for phrases now

    
    public String execute(Player player) {

        Random rand = new Random();

        int fuelLeakage = rand.Next(player.getCurrentFuel() + 1);
        if (fuelLeakage == 0) {
            fuelLeakage++; // 1 to player.getCurrentFuel()
        }
        if (player.getCurrentFuel() <= 0) return "You left your fuel tank open, but you have no fuel to leak!";
        player.travel(fuelLeakage);
        int msg = rand.Next(losePhrases.Length);
        return String.Format(losePhrases[msg], fuelLeakage);
    }

}

