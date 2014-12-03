

/**
 * Private class to handle money events.
 *
 * @author ngraves3
 *
 */

using System;

public class MoneyStrategy : EventStrategy {

    /**
     * Phrases for gaining money.
     */
    private String[] addPhrases = {
            "Your last lotto ticket was worth %d! credits",
            "%d credits fell into your hand!",
            "You found %d credits in your back pocket!",
            "An old man gave you %d credits (and a weird wink...)",
            "You helped a little old lady carry her groceries "
                            + "to the car and she gave you %d credits!"};

    /**
     * Phrases for losing money.
     */
    private String[] minusPhrases = {"You lost %d credits playing a shell game!",
            "%d credits fell out of your pocket! Oops!",
            "You were mugged and had %d credits stolen!",
            "Unexpected taxes in this market cost you %d credits!",
            "You gave %d credits to a crying orphan!"};

    
    public String execute(Player player) {
        Random rand = new Random();
        int money = rand.Next(player.getMoney() * 2 + 1);
        money -= player.getMoney();

        if (money == 0) {
            money++;
        }

        player.addMoney(money); //adding negative money is taking money

        if (money > 0) {
            return String.Format(addPhrases[rand.Next(addPhrases.Length)], money);
        } else {
            return String.Format(minusPhrases[rand.Next(minusPhrases.Length)], -1 * money);
        }
    }
}

