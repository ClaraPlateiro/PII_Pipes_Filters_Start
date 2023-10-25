using System;
using System.Drawing;
using CompAndDel;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    public class TwitterFilter: IFilter
    {
        public IPicture Filter (IPicture picture)
        {
            var twitter = new TwitterImage();
            string imagePath = "finalResult.jpg";
            string tweetText = "Imagen editada";
            string publishResult = twitter.PublishToTwitter(tweetText, imagePath);
            Console.WriteLine("Resultado:" + publishResult);
            return picture;
        }
    }
}