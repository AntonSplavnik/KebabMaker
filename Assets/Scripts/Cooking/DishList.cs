using System.Collections.Generic;
using UnityEngine;

namespace Cooking
{
    public class DishList : MonoBehaviour
    {
            private List<Dish> dishList = new List<Dish>();

            private void Start()
            {
                dishList.Add(new Dish("Burger", 20f));
                dishList.Add(new Dish("Salad", 20f));
                dishList.Add(new Dish("Fries", 20f));

            }
    }
}