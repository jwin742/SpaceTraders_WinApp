
/**
 * This class is a gadget that reduces fuel cost for the ship.
 *
 * @author ngraves3
 *
 */

using System;

public class FuelGadget : AbstractGadget {

    /**
     * Divide current fuel cost by this amount.
     */
    private int fuelModifier = 2;

    /**
     * Need to know original cost to avoid truncation errors.
     */
    private int originalFuelCost;

    /**
     * Constructor for a fuel gadget.
     * 
     * @param ship
     *        the ship to affect
     */
    public FuelGadget(Ship ship)
        : base("Efficient Engine", ship)
    {
        originalFuelCost = ship.getFuelCost();
    }

    
    public override int getPrice() {
        return 500;
    }

    
    protected override bool effect() {
        if (!effectApplied) {
            ship.setFuelCost(Math.Max(1, originalFuelCost / fuelModifier));
            effectApplied = true;
            return true;
        }

        return false;
    }

    
    protected override bool uneffect() {
        if (effectApplied) {
            ship.setFuelCost(originalFuelCost);
            effectApplied = false;
            return true;
        }
        return false;
    }

}
