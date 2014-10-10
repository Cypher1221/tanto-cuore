using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class Card
    {
        int cardNumber;
        int VP;
        int cost;
        int draws;
        int employments;
        int servings;
        int love;
        int chamberCost = 1;
        bool specialAbility = false;
        bool variableVP = false;
        bool canBeChambered = false;
        public int cardValue = 0;
        public Card(int cardNumberN)
        {
            cardNumber = cardNumberN;
            VP = 0;
            switch(cardNumber){
                case 1:
                    VP = 6;
                    cost = 9;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    cardValue = 9;
                    break;
                case 2:
                    VP = 1;
                    cost = 3;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    canBeChambered = true;
                    chamberCost = 2;
                    cardValue = 4;
                    break;
                case 3:
                    VP = 3;
                    cost = 7;
                    draws = 3;
                    employments = 1;
                    servings = 0;
                    love = 0;
                    cardValue = 4;
                    break;
                case 4:
                    VP = 0;
                    cost = 6;
                    draws = 1;
                    employments = 1;
                    servings = 1;
                    love = 1;
                    variableVP = true;
                    cardValue = 3;
                    break;
                case 5:
                    VP = 0;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 2;
                    break;
                case 6:
                    VP = 0;
                    cost = 5;
                    draws = 0;
                    employments = 1;
                    servings = 0;
                    love = 3;
                    specialAbility = true;
                    cardValue = 4;
                    break;
                case 7:
                    VP = 0;
                    cost = 5;
                    draws = 1;
                    employments = 0;
                    servings = 2;
                    love = 0;
                    specialAbility = true;
                    cardValue = 3;
                    break;
                case 8:
                    VP = 0;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 1;
                    specialAbility = true;
                    cardValue = 3;
                    break;
                case 9:
                    VP = 0;
                    cost = 4;
                    draws = 2;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 5;
                    break;
                case 10:
                    VP = 0;
                    cost = 4;
                    draws = 1;
                    employments = 0;
                    servings = 1;
                    love = 1;
                    cardValue = 5;
                    break;
                case 11:
                    VP = 0;
                    cost = 4;
                    draws = 2;
                    employments = 2;
                    servings = 0;
                    love = 0;
                    cardValue = 4;
                    break;
                case 12:
                    VP = 0;
                    cost = 3;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 2;
                    specialAbility = true;
                    cardValue = 3;
                    break;
                case 13:
                    VP = 0;
                    cost = 3;
                    draws = 0;
                    employments = 0;
                    servings = 2;
                    love = 0;
                    cardValue = 4;
                    break;
                case 14:
                    VP = 0;
                    cost = 3;
                    draws = 0;
                    employments = 0;
                    servings = 1;
                    love = 0;
                    specialAbility = true;
                    cardValue = 4;
                    break;
                case 15:
                    VP = 0;
                    cost = 3;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 2;
                    variableVP = true;
                    canBeChambered = true;
                    cardValue = 5;
                    break;
                case 16:
                    VP = 1;
                    cost = 2;
                    draws = 0;
                    employments = 1;
                    servings = 0;
                    love = 0;
                    variableVP = true;
                    canBeChambered = true;
                    cardValue = 4;
                    break;
                case 17:
                    VP = 1;
                    cost = 2;
                    draws = 1;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    variableVP = true;
                    canBeChambered = true;
                    cardValue = 4;
                    break;
                case 18:
                    VP = 1;
                    cost = 2;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 1;
                    variableVP = true;
                    canBeChambered = true;
                    cardValue = 4;
                    break;
                case 19:
                    VP = -3;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 4;
                    break;
                case 20:
                    VP = -4;
                    cost = 4;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 4;
                    break;
                case 21:
                    VP = 2;
                    cost = 7;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 7;
                    break;
                case 22:
                    VP = 0;
                    cost = 6;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 5;
                    break;
                case 23:
                    VP = 2;
                    cost = 6;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 6;
                    break;
                case 24:
                    VP = 2;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 6;
                    break;
                case 25:
                    VP = 0;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 5;
                    break;
                case 26:
                    VP = 1;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 7;
                    break;
                case 27:
                    VP = 1;
                    cost = 5;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 6;
                    break;
                case 28:
                    VP = 1;
                    cost = 4;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 6;
                    break;
                case 29:
                    VP = 0;
                    cost = 4;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    cardValue = 3;
                    break;
                case 30:
                    VP = -1;
                    cost = 2;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 0;
                    specialAbility = true;
                    variableVP = true;
                    cardValue = 3;
                    break;
                case 31:
                    VP = 0;
                    cost = 7;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 3;
                    cardValue = 2;
                    break;
                case 32:
                    VP = 0;
                    cost = 4;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 2;
                    cardValue = 5;
                    break;
                case 33:
                    VP = 0;
                    cost = 1;
                    draws = 0;
                    employments = 0;
                    servings = 0;
                    love = 1;
                    cardValue = 9;
                    break;
            }
        }
        
        public int getCardNumber()
        {
            return cardNumber;
        }

        public int getVP()
        {
            return VP;
        }

        public int getLove()
        {
            return love;
        }

        public int getServings()
        {
            return servings;
        }

        public int getChamperCost()
        {
            return chamberCost;
        }

        public int getCost()
        {
            return cost;
        }

        public int getEmployments()
        {
            return employments;
        }

        public bool getCanBeChambered()
        {
            return canBeChambered;
        }

        public bool getVariableVP()
        {
            return variableVP;
        }

        public bool getSpecialAbility()
        {
            return specialAbility;
        }

        public int getDraws()
        {
            return draws;
        }
    }
}
