

namespace Delegates
{
    public static class MaxExtension
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null || !collection.Any())
            {
                throw new Exception("Коллекция пуста.");
            }

            T maxElement = collection.First();
            float maxNumber = convertToNumber(maxElement);

            foreach (var element in collection)
            {
                float currentNumber = convertToNumber(element);
                if (currentNumber > maxNumber)
                {
                    maxElement = element;
                    maxNumber = currentNumber;
                }
            }
            return maxElement;
        }
    }
}