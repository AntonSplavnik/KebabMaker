using Unity.VisualScripting;

namespace Cooking
{
    public class Dish
    {
        public string Name { get; set; }
        public float CookingTime {get; set;}
        
        public Dish(string Namespace, float CookingTime)
        {
            Name = Namespace;
            CookingTime = CookingTime;
        }
    }

}