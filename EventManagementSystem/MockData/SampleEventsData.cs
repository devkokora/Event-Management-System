using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using EventManagementSystem.Models;

namespace EventManagementSystem.MockData
{
    public class SampleEventsData
    {
        public static Random rnd = new Random();
        public static Dictionary<string, List<Tuple<string, string>>> TitleAndShortDescription { get; } =
            new Dictionary<string, List<Tuple<string, string>>>()
            {
                { "Sport", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Champions League Final", "Top European club football match"),
                        Tuple.Create("Super Bowl", "NFL championship game"),
                        Tuple.Create("NBA Finals", "NBA championship series"),
                        Tuple.Create("Wimbledon", "Prestigious tennis tournament"),
                        Tuple.Create("Tour de France", "Famous cycling race"),
                        Tuple.Create("Olympic Games", "Global multi-sport event"),
                        Tuple.Create("World Cup", "International football tournament"),
                        Tuple.Create("US Open", "Major tennis championship"),
                        Tuple.Create("Formula 1 Grand Prix", "Premier F1 racing event"),
                        Tuple.Create("Rugby World Cup", "International rugby competition"),
                        Tuple.Create("Cricket World Cup", "Top cricket tournament"),
                        Tuple.Create("Masters Tournament", "Major golf championship"),
                        Tuple.Create("Indianapolis 500", "Iconic car race"),
                        Tuple.Create("Stanley Cup Finals", "NHL championship series"),
                        Tuple.Create("The Ashes", "Historic cricket series"),
                        Tuple.Create("Six Nations Championship", "Annual rugby tournament"),
                        Tuple.Create("X Games", "Extreme sports event"),
                        Tuple.Create("Ironman Triathlon", "Challenging triathlon race"),
                        Tuple.Create("WWE WrestleMania", "Flagship wrestling event"),
                        Tuple.Create("Boxing World Championship", "Top boxing title fight")
                    }
                },
                { "Conferences", new List<Tuple<string, string>>
                    {
                        Tuple.Create("TechCrunch Disrupt", "Startup and tech conference"),
                        Tuple.Create("TED Conference", "Ideas worth spreading"),
                        Tuple.Create("SXSW Conference", "Creative industries event"),
                        Tuple.Create("Google I/O", "Google developer conference"),
                        Tuple.Create("Apple WWDC", "Apple developer conference"),
                        Tuple.Create("Microsoft Ignite", "Tech innovations event"),
                        Tuple.Create("CES", "Consumer electronics showcase"),
                        Tuple.Create("Web Summit", "Global tech conference"),
                        Tuple.Create("Dreamforce", "Salesforce annual event"),
                        Tuple.Create("AWS re:Invent", "Amazon Web Services event"),
                        Tuple.Create("Mobile World Congress", "Mobile industry conference"),
                        Tuple.Create("Adobe MAX", "Creative professionals conference"),
                        Tuple.Create("RSA Conference", "Cybersecurity event"),
                        Tuple.Create("HIMSS Global Conference", "Healthcare IT event"),
                        Tuple.Create("Gartner Symposium", "IT leadership conference"),
                        Tuple.Create("Oracle OpenWorld", "Oracle user conference"),
                        Tuple.Create("IBM Think", "IBM's tech conference"),
                        Tuple.Create("Social Media Marketing World", "Social media strategies event"),
                        Tuple.Create("Climate Change Summit", "Environmental policy conference"),
                        Tuple.Create("World Economic Forum", "Global economic meeting")
                    }
                },
                { "Expo", new List<Tuple<string, string>>
                    {
                        Tuple.Create("World Expo", "International exhibition"),
                        Tuple.Create("Comic-Con International", "Pop culture convention"),
                        Tuple.Create("E3 Expo", "Electronic Entertainment Expo"),
                        Tuple.Create("Art Basel", "Contemporary art fair"),
                        Tuple.Create("Consumer Electronics Show", "Tech innovation showcase"),
                        Tuple.Create("Auto Expo", "Automobile industry exhibition"),
                        Tuple.Create("Book Expo America", "Publishing industry fair"),
                        Tuple.Create("Paris Air Show", "Aerospace exhibition"),
                        Tuple.Create("Canton Fair", "China's largest trade fair"),
                        Tuple.Create("International Home + Housewares Show", "Home products expo"),
                        Tuple.Create("Gamescom", "Video game trade fair"),
                        Tuple.Create("Dubai Airshow", "Aerospace trade show"),
                        Tuple.Create("Anime Expo", "Anime and manga convention"),
                        Tuple.Create("National Hardware Show", "Hardware industry event"),
                        Tuple.Create("Magic Fashion Trade Show", "Apparel trade show"),
                        Tuple.Create("SHRM Annual Conference", "HR management event"),
                        Tuple.Create("Bio International Convention", "Biotech industry expo"),
                        Tuple.Create("National Restaurant Association Show", "Foodservice trade show"),
                        Tuple.Create("Pack Expo", "Packaging industry event"),
                        Tuple.Create("Craft Brewers Conference & BrewExpo", "Brewing industry event")
                    }
                },
                { "Concert", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Coachella", "Annual music and arts festival"),
                        Tuple.Create("Glastonbury Festival", "Largest greenfield festival"),
                        Tuple.Create("Lollapalooza", "Multi-genre music festival"),
                        Tuple.Create("Bonnaroo", "Camping music festival"),
                        Tuple.Create("Reading Festival", "Rock music festival"),
                        Tuple.Create("Rock in Rio", "Major rock music festival"),
                        Tuple.Create("Tomorrowland", "Electronic dance music festival"),
                        Tuple.Create("Burning Man", "Community and art festival"),
                        Tuple.Create("Ultra Music Festival", "Electronic music festival"),
                        Tuple.Create("Wireless Festival", "Hip hop and urban music festival"),
                        Tuple.Create("Stagecoach Festival", "Country music festival"),
                        Tuple.Create("Newport Folk Festival", "Folk music festival"),
                        Tuple.Create("Austin City Limits", "Music festival in Texas"),
                        Tuple.Create("Voodoo Experience", "New Orleans music festival"),
                        Tuple.Create("Electric Daisy Carnival", "Electronic dance music fest"),
                        Tuple.Create("Isle of Wight Festival", "Historic UK music festival"),
                        Tuple.Create("Download Festival", "Heavy metal music festival"),
                        Tuple.Create("Sziget Festival", "Major European music festival"),
                        Tuple.Create("Roskilde Festival", "Denmark's music festival"),
                        Tuple.Create("Primavera Sound", "Indie and alternative music festival")
                    }
                },
                { "Festival", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Carnival of Venice", "Historic masked festival"),
                        Tuple.Create("Oktoberfest", "German beer festival"),
                        Tuple.Create("Diwali", "Festival of Lights"),
                        Tuple.Create("Chinese New Year", "Lunar New Year celebrations"),
                        Tuple.Create("Holi", "Festival of Colors"),
                        Tuple.Create("Mardi Gras", "New Orleans carnival festival"),
                        Tuple.Create("St. Patrick's Day", "Irish cultural celebration"),
                        Tuple.Create("La Tomatina", "Spanish tomato fight"),
                        Tuple.Create("Rio Carnival", "Brazilian pre-Lent festival"),
                        Tuple.Create("Running of the Bulls", "Pamplona's bull run"),
                        Tuple.Create("Harbin Ice Festival", "Ice and snow sculptures"),
                        Tuple.Create("Gion Matsuri", "Kyoto's traditional festival"),
                        Tuple.Create("Burning Man", "Community and art festival"),
                        Tuple.Create("Day of the Dead", "Mexican remembrance festival"),
                        Tuple.Create("Eid al-Fitr", "End of Ramadan celebration"),
                        Tuple.Create("Hanami", "Cherry blossom viewing"),
                        Tuple.Create("Bastille Day", "French national day"),
                        Tuple.Create("Christmas Markets", "Holiday markets in Europe"),
                        Tuple.Create("Edinburgh Fringe Festival", "World's largest arts festival"),
                        Tuple.Create("Notting Hill Carnival", "London's Caribbean carnival")
                    }
                },
                { "Art", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Art Basel Miami Beach", "Contemporary art fair"),
                        Tuple.Create("Venice Biennale", "International art exhibition"),
                        Tuple.Create("Documenta", "Modern art exhibition"),
                        Tuple.Create("Frieze Art Fair", "Contemporary art fair"),
                        Tuple.Create("Whitney Biennial", "American contemporary art"),
                        Tuple.Create("Armory Show", "International art fair"),
                        Tuple.Create("Sculpture by the Sea", "Outdoor sculpture exhibition"),
                        Tuple.Create("Art Paris", "Modern and contemporary art fair"),
                        Tuple.Create("Hong Kong Art Fair", "Asia's leading art fair"),
                        Tuple.Create("Berlin Art Week", "Contemporary art showcase"),
                        Tuple.Create("Sydney Contemporary", "Australasian art fair"),
                        Tuple.Create("FIAC", "Contemporary art fair in Paris"),
                        Tuple.Create("Artissima", "Contemporary art fair in Italy"),
                        Tuple.Create("SP-Arte", "São Paulo's art fair"),
                        Tuple.Create("TEFAF Maastricht", "Fine art and antiques fair"),
                        Tuple.Create("ArteBA", "Buenos Aires art fair"),
                        Tuple.Create("Contemporary Istanbul", "Turkey's leading art fair"),
                        Tuple.Create("India Art Fair", "New Delhi's art fair"),
                        Tuple.Create("Zona Maco", "Mexico's art fair"),
                        Tuple.Create("Art Dubai", "Leading Middle Eastern art fair")
                    }
                },
                { "Community", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Neighborhood Block Party", "Local community gathering"),
                        Tuple.Create("Community Clean-Up Day", "Neighborhood improvement event"),
                        Tuple.Create("Farmers Market", "Local produce and goods market"),
                        Tuple.Create("Charity Fun Run", "Community fundraising run"),
                        Tuple.Create("Local Food Festival", "Celebration of local cuisine"),
                        Tuple.Create("Outdoor Movie Night", "Community film screening"),
                        Tuple.Create("Craft Fair", "Local handmade goods market"),
                        Tuple.Create("Community Garden Project", "Neighborhood gardening initiative"),
                        Tuple.Create("Cultural Heritage Festival", "Celebration of local culture"),
                        Tuple.Create("Volunteer Day", "Community service event"),
                        Tuple.Create("Street Art Fair", "Exhibition of local artists"),
                        Tuple.Create("Youth Sports League", "Local youth sports activities"),
                        Tuple.Create("Public Library Storytime", "Children's reading event"),
                        Tuple.Create("Senior Center Dance", "Social event for seniors"),
                        Tuple.Create("Community Theater Play", "Local theater performance"),
                        Tuple.Create("Health and Wellness Fair", "Community health event"),
                        Tuple.Create("Pet Adoption Event", "Animal adoption drive"),
                        Tuple.Create("Neighborhood Watch Meeting", "Community safety meeting"),
                        Tuple.Create("Park Picnic Day", "Community picnic event"),
                        Tuple.Create("Environmental Awareness Day", "Eco-friendly activities")
                    }
                },
                { "Holiday", new List<Tuple<string, string>>
                    {
                        Tuple.Create("New Year's Eve Party", "Year-end celebration"),
                        Tuple.Create("Christmas Celebration", "Holiday festivities"),
                        Tuple.Create("Easter Egg Hunt", "Children's Easter activity"),
                        Tuple.Create("Fourth of July Fireworks", "Independence Day event"),
                        Tuple.Create("Thanksgiving Dinner", "Traditional holiday meal"),
                        Tuple.Create("Valentine's Day Dance", "Romantic celebration"),
                        Tuple.Create("Halloween Party", "Spooky celebration"),
                        Tuple.Create("St. Patrick's Day Parade", "Irish cultural event"),
                        Tuple.Create("Hanukkah Celebration", "Jewish holiday festivities"),
                        Tuple.Create("Ramadan Iftar", "Breaking the fast event"),
                        Tuple.Create("Cinco de Mayo Fiesta", "Mexican heritage celebration"),
                        Tuple.Create("Mother's Day Brunch", "Celebration for mothers"),
                        Tuple.Create("Father's Day BBQ", "Celebration for fathers"),
                        Tuple.Create("Labor Day Picnic", "End of summer event"),
                        Tuple.Create("Memorial Day Parade", "Honoring military personnel"),
                        Tuple.Create("Veterans Day Ceremony", "Honoring veterans"),
                        Tuple.Create("Independence Day Celebration", "National holiday festivities"),
                        Tuple.Create("Oktoberfest Party", "German beer festival celebration"),
                        Tuple.Create("Diwali Festival", "Festival of Lights celebration"),
                        Tuple.Create("Chinese New Year Gala", "Lunar New Year celebration")
                    }
                }
            };

        public static List<Tuple<string, string>> GetTitleAndShortDescription(string category)
        {
            return TitleAndShortDescription[category];
        }

        public static string GetRandomDescription()
        {
            var descriptions = new string[]
            {
                "Join us for an immersive journey into the heart of creativity at the \"Artistry Unleashed\" exhibition. Explore a vibrant tapestry of contemporary artworks spanning diverse mediums and themes. From avant-garde installations to thought-provoking sculptures, this showcase promises to ignite your imagination and provoke introspection. Engage with the artists, delve into their creative process, and witness the power of art to inspire, challenge, and transform. Don't miss this opportunity to experience the boundless expression of human creativity in all its forms.",
                "Step into a world of rhythm and melody at the \"Harmony in Motion\" concert series. Let the enchanting melodies and soulful harmonies transport you to a realm of musical bliss. From classical symphonies to contemporary compositions, this concert series celebrates the universal language of music in all its diversity. Immerse yourself in the captivating performances of virtuoso musicians and orchestras, as they weave together a tapestry of sonic delights. Whether you're a seasoned aficionado or a casual listener, \"Harmony in Motion\" promises an unforgettable auditory experience that resonates long after the final note fades.",
                "Embark on a culinary odyssey at the \"Flavors of the World\" food festival, where gastronomic delights await at every turn. Indulge your senses in a symphony of aromas, flavors, and textures as you sample cuisines from around the globe. From tantalizing street food to exquisite gourmet creations, this festival showcases the rich tapestry of culinary traditions that define our world. Savor mouthwatering dishes prepared by master chefs, discover new culinary treasures, and immerse yourself in the vibrant ambiance of food, music, and culture. Whether you're a passionate foodie or simply curious, \"Flavors of the World\" offers a feast for the senses that promises to delight and inspire.\r\n\r\n",
                "Dive into a world of wonder and imagination at the \"Enchanted Forest\" interactive art installation. Wander through lush landscapes, enchanted groves, and mystical realms as you embark on a journey of discovery and whimsy. Encounter captivating sculptures, vibrant murals, and interactive installations that blur the lines between reality and fantasy. Immerse yourself in the magic of light, color, and sound as you explore hidden nooks and secret pathways. Whether you're young or young at heart, the \"Enchanted Forest\" offers an enchanting escape into a realm where dreams come to life and imagination knows no bounds.",
                "Experience the thrill of discovery at the \"Innovation Summit,\" where cutting-edge technologies and groundbreaking ideas converge to shape the future. Engage with visionary thought leaders, industry pioneers, and innovators from around the globe as they share insights, best practices, and bold visions for tomorrow. From artificial intelligence to renewable energy, biotechnology to space exploration, this summit explores the frontiers of innovation across diverse fields and disciplines. Dive into thought-provoking discussions, hands-on workshops, and immersive demonstrations that showcase the transformative power of innovation. Whether you're an entrepreneur, a scientist, or a curious mind, the \"Innovation Summit\" offers a glimpse into the limitless possibilities that lie ahead."
            };
            return descriptions[rnd.Next(descriptions.Length)];
        }

        public static Tuple<DateOnly, DateOnly> GetRandomStartEndDate()
        {
            var startDate = new DateTime(2025, 1, 1);
            var endDate = new DateTime(2026, 1, 1);

            var rndStDate = startDate.AddDays(rnd.Next((endDate - startDate).Days));
            var rndEnDate = rndStDate.AddDays(rnd.Next(30));
            return Tuple.Create(
                new DateOnly(rndStDate.Year, rndStDate.Month, rndStDate.Day),
                new DateOnly(rndEnDate.Year, rndEnDate.Month, rndEnDate.Day));
        }

        public static string GetRandomVenueName()
        {
            string[] prefixes = { "Grand", "Elegant", "Majestic", "Royal", "Luxurious", "Opulent", "Exquisite", "Regal", "Spectacular", "Glorious", "Splendid", "Sumptuous", "Imperial", "Prestigious", "Magnificent" };
            string[] suffixes = { "Hall", "Manor", "Palace", "Mansion", "Estate", "Castle", "Resort", "Lodge", "Court", "Pavilion", "Stadium" };

            string prefix = prefixes[rnd.Next(prefixes.Length)];
            string suffix = suffixes[rnd.Next(suffixes.Length)];

            return $"{prefix} {suffix}";
        }

        public static Tuple<double, double> GetRandomLatLng()
        {
            double minLat = -90;
            double maxLat = 90;
            double minLong = -180;
            double maxLong = 180;

            double latitude = rnd.NextDouble() * (maxLat - minLat) + minLat;
            double longitude = rnd.NextDouble() * (maxLong - minLong) + minLong;

            return Tuple.Create(latitude, longitude);
        }

        public static string GetRandomCountry()
        {
            var countryNames = new string[]
            {
                "Thailand",
                "Japan",
                "USA",
                "India",
                "China",
                "Russia",
            };
            return countryNames[rnd.Next(countryNames.Length)];
        }

        public static string GenerateRandomAddress(string country)
        {
            Random random = new Random();

            Dictionary<string, string[]> streetNamesByCountry = new Dictionary<string, string[]>
            {
                { "Thailand", new string[] { "Sukhumvit", "Silom", "Ratchadamri", "Phahonyothin", "Rama IV", "Sathorn", "Charoenkrung", "Siam", "Phetchaburi", "Yaowarat" } },
                { "Japan", new string[] { "Ginza", "Shibuya", "Shinjuku", "Harajuku", "Asakusa", "Akihabara", "Roppongi", "Ueno", "Shinagawa", "Ryogoku" } },
                { "USA", new string[] { "Main", "Maple", "Oak", "Elm", "Cedar", "Washington", "Lincoln", "Park", "Adams", "Jefferson" } },
                { "India", new string[] { "MG Road", "Indiranagar", "Jayanagar", "Whitefield", "Malleshwaram", "Koramangala", "HSR Layout", "Bellandur", "Electronic City", "Basavanagudi" } },
                { "China", new string[] { "Nanjing Road", "Beijing Road", "Huaihai Road", "West Lake Avenue", "People's Square", "East Nanjing Road", "Wangfujing Street", "Tiananmen Square", "Zhongshan Road", "Nanshan Road" } },
                { "Russia", new string[] { "Tverskaya", "Arbat", "Kuznetsky Most", "Novy Arbat", "Sadovaya-Kudrinskaya", "Petrovka", "Kutuzovsky Prospekt", "Vorobyovy Gory", "Komsomolsky Prospekt", "Leninsky Prospekt" } }
            };

            Dictionary<string, string[]> citiesByCountry = new Dictionary<string, string[]>
            {
                { "Thailand", new string[] { "Bangkok", "Phuket", "Chiang Mai", "Pattaya", "Krabi", "Hua Hin", "Ayutthaya", "Kanchanaburi", "Samut Prakan", "Nakhon Ratchasima" } },
                { "Japan", new string[] { "Tokyo", "Osaka", "Kyoto", "Yokohama", "Sapporo", "Nagoya", "Fukuoka", "Kobe", "Hiroshima", "Sendai" } },
                { "USA", new string[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose" } },
                { "India", new string[] { "Mumbai", "Delhi", "Bangalore", "Hyderabad", "Chennai", "Kolkata", "Ahmedabad", "Pune", "Surat", "Jaipur" } },
                { "China", new string[] { "Shanghai", "Beijing", "Guangzhou", "Shenzhen", "Tianjin", "Chengdu", "Nanjing", "Wuhan", "Hangzhou", "Chongqing" } },
                { "Russia", new string[] { "Moscow", "Saint Petersburg", "Novosibirsk", "Yekaterinburg", "Nizhny Novgorod", "Kazan", "Chelyabinsk", "Omsk", "Samara", "Rostov-on-Don" } }
            };

            string city = GetRandomItem(citiesByCountry[country]);
            string streetName = GetRandomItem(streetNamesByCountry[country]);

            string postalCode = random.Next(10000, 99999).ToString();

            string address = $"{streetName} St., {city}, {country} {postalCode}";
            return address;
        }

        public static T GetRandomItem<T>(T[] array)
        {
            return array[rnd.Next(array.Length)];
        }

        public static List<string> GetAllImgsUrlBytype(string category)
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
            var cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;

            string folderName = $"{category.ToLower()}";

            var resourceList = cloudinary.ListResources(new ListResourcesByPrefixParams()
            {
                Prefix = $"{folderName}/",
                Type = "upload",
                MaxResults = 20
            });

            var urlList = new List<string>();

            foreach (var res in resourceList.Resources)
            {
                urlList.Add(res.SecureUrl.ToString());
            }

            return urlList;
        }

        public static List<Transport> GetRandomTransport()
        {
            var transportsTemp = Enum.GetValues<Transport>();
            var transportsCount = rnd.Next(transportsTemp.Length);
            var transports = new List<Transport>();

            for (int i = 0; i < transportsCount; i++)
            {
                transports.Add(transportsTemp[i]);
            }

            return transports;
        }
    }
}
