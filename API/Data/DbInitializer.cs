using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    public static async Task Initialize(StoreContext context)
    {
        if (!context.InventoryItems.Any() && !context.Products.Any())
        {

            Random r = new Random();

            var Products = new List<Product>
            {
                new Product
                {
                    Name = "Bryza Nadmorska",
                    Description = "Bryza Nadmorska to perfumy, które przeniosą Cię na wybrzeże oceanu. Ich świeże aromaty nawiązują do morskiego powietrza i wolności. Nuty głowy to bergamotka i zielona mandarynka, które otwierają się jak bryza nad morzem. W sercu tych perfum znajdują się nuty morskiej soli i alg, co nadaje im charakterystyczny akcent. Baza to drzewo cedrowe i piżmo, co dodaje trwałości temu wyjątkowemu zapachowi.",
                    PictureUrl = "/images/products/Bryza Nadmorska.jpg",
                    PictureUrl2 = "/images/products/Bryza Nadmorska2.jpg",
                    PictureUrl3 = "/images/products/Bryza Nadmorska3.jpg",
                    Sex = "Uni",
                    Brand = "Brand1",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Cynamonowa Pasja",
                    Description = "Cynamonowa Pasja to perfumy z nutami cynamonu i przypraw. Ich aromat jest ciepły i kuszący. Nuty głowy to cynamon i goździk, które otwierają zapach jak aromatyczna przyprawa. W sercu tych perfum znajduje się wanilia i gałka muszkatołowa, a baza to piżmo i drzewo sandałowe. To zapach, który przypomina przytulność i ciepło domowego piekarnika.",
                    PictureUrl = "/images/products/Cynamonowa Pasja.jpg",
                    PictureUrl2 = "/images/products/Cynamonowa Pasja2.jpg",
                    PictureUrl3 = "/images/products/Cynamonowa Pasja3.jpg",
                    Sex = "Uni",
                    Brand = "Brand1",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Deszcz Kwiatów",
                    Description = "Deszcz Kwiatów to perfumy z nutami świeżo rozkwitłych kwiatów. Ich aromat jest pełen kwiatowej harmonii i świeżości. Nuty głowy to kwiaty pomarańczy i białe kwiaty, które otwierają zapach jak kwiatowy deszcz. W sercu tych perfum znajdują się nuty róż i jaśminu, a baza to białe piżmo i piżmo ambrowe. To zapach, który przypomina romantyczne spacery w ogrodzie pełnym kwiatów.",
                    PictureUrl = "/images/products/Deszcz Kwiatów.jpg",
                    PictureUrl2 = "/images/products/Deszcz Kwiatów2.jpg",
                    PictureUrl3 = "/images/products/Deszcz Kwiatów3.jpg",
                    Sex = "Female",
                    Brand = "Brand1",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Egzotyczna Przygoda",
                    Description = "Egzotyczna Przygoda to perfumy, które przenoszą do egzotycznych miejsc i zapraszają do odkrywania nowych kultur. Ich aromat jest pełen tajemnicy i egzotycznego uroku. Nuty głowy to mandarynka i mango, które otwierają zapach jak pierwszy krok w obcym kraju. W sercu tych perfum znajdują się nuty kwiatowe, takie jak jaśmin i frangipani, a baza to drzewo sandałowe i piżmo. To zapach, który inspiruje do podróży i eksploracji.",
                    PictureUrl = "/images/products/Egzotyczna Przygoda.jpg",
                    PictureUrl2 = "/images/products/Egzotyczna Przygoda2.jpg",
                    PictureUrl3 = "/images/products/Egzotyczna Przygoda3.jpg",
                    Sex = "Uni",
                    Brand = "Brand1",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Ekskluzywna Noc",
                    Description = "Ekskluzywna Noc to perfumy, które wprowadzą Cię w magiczną atmosferę nocnego życia. Ich aromat jest subtelny, ale trwały, idealny na wieczorne wyjścia. Nuty głowy to świeży cytrus i bergamotka, które stopniowo przechodzą w orientalne nuty serca, takie jak paczula i wanilia. Bazą tych perfum jest piżmo i cedr, nadający im głębię i elegancję. To zapach, który zostawia niezapomniane wrażenie, podobnie jak noc w ekskluzywnym klubie.",
                    PictureUrl = "/images/products/Ekskluzywna Noc.jpg",
                    PictureUrl2 = "/images/products/Ekskluzywna Noc2.jpg",
                    PictureUrl3 = "/images/products/Ekskluzywna Noc3.jpg",
                    Sex = "Female",
                    Brand = "Brand2",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Ekskluzywny Styl",
                    Description = "Ekskluzywny Styl to perfumy dla osób o wyrafinowanym guście. Ich aromat jest elegancki i luksusowy. Nuty głowy to grejpfrut i cytryna, które otwierają zapach jak szlachetny aperitif. W sercu tych perfum znajdują się nuty kwiatowe, takie jak irys i jaśmin, a baza to drzewo sandałowe i białe piżmo. To zapach, który podkreśla ekskluzywność i styl.",
                    PictureUrl = "/images/products/Ekskluzywny Styl.jpg",
                    PictureUrl2 = "/images/products/Ekskluzywny Styl2.jpg",
                    PictureUrl3 = "/images/products/Ekskluzywny Styl3.jpg",
                    Sex = "Male",
                    Brand = "Brand2",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Elegancja Gentlemana",
                    Description = "Perfumy Elegancja Gentlemana są dla mężczyzn o niezwykłym stylu i klasie. Ich aromat jest wyrafinowany z nutami skóry i cedru. To zapach, który podkreśla elegancję i wyjątkowość.",
                    PictureUrl = "/images/products/Elegancja Gentlemana.jpg",
                    PictureUrl2 = "/images/products/Elegancja Gentlemana2.jpg",
                    PictureUrl3 = "/images/products/Elegancja Gentlemana3.jpg",
                    Sex = "Male",
                    Brand = "Brand2",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Kawowy Zestaw",
                    Description = "Kawowy Zestaw to perfumy z aromatem świeżo zaparzonej kawy. Ich zapach jest energetyczny i pobudzający. Nuty głowy to intensywna kawa i gałka muszkatołowa, które otwierają zapach jak ulubiona kawa. W sercu tych perfum znajdują się nuty cynamonu i wanilii, a baza to drzewo sandałowe i białe piżmo. To zapach dla miłośników kawy i intensywnych doznań.",
                    PictureUrl = "/images/products/Kawowy Zestaw.jpg",
                    PictureUrl2 = "/images/products/Kawowy Zestaw2.jpg",
                    PictureUrl3 = "/images/products/Kawowy Zestaw3.jpg",
                    Sex = "Uni",
                    Brand = "Brand3",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Kwiatowy Urok",
                    Description = "Kwiatowy Urok to perfumy, które celebrują piękno natury. Ich delikatny bukiet kwiatowy otwiera się nutami róż, jaśminu i piwonii, co nadaje im lekkości i świeżości. Nuty bazowe to ciepły białe piżmo i drzewo sandałowe, które dodają głębi temu subtelnie kwiatowemu zapachowi. To perfumy, które sprawią, że poczujesz się jak w ogrodzie pełnym kwiatów, niezależnie od pory roku.",
                    PictureUrl = "/images/products/Kwiatowy Urok.jpg",
                    PictureUrl2 = "/images/products/Kwiatowy Urok2.jpg",
                    PictureUrl3 = "/images/products/Kwiatowy Urok3.jpg",
                    Sex = "Female",
                    Brand = "Brand3",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Magiczny Las",
                    Description = "Magiczny Las to perfumy, które przenoszą do magicznego lasu. Ich aromat jest tajemniczy i pełen czarów natury. Nuty głowy to jagody i cyprys, które otwierają zapach jak wstęp do lasu. W sercu tych perfum znajdują się nuty drzewne i balsamiczne, a baza to wetiweria i piżmo. To zapach, który otwiera drzwi do magicznego świata przyrody.",
                    PictureUrl = "/images/products/Magiczny Las.jpg",
                    PictureUrl2 = "/images/products/Magiczny Las2.jpg",
                    PictureUrl3 = "/images/products/Magiczny Las3.jpg",
                    Sex = "Uni",
                    Brand = "Brand3",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Męska Ekstrawagancja",
                    Description = "Perfumy Męska Ekstrawagancja są dla mężczyzn, którzy cenią sobie luksus i wyjątkowość. Ich aromat jest intensywny i zmysłowy z nutami skóry i ambry. To zapach, który podkreśla męską siłę i elegancję.",
                    PictureUrl = "/images/products/Męska Ekstrawagancja.jpg",
                    PictureUrl2 = "/images/products/Męska Ekstrawagancja2.jpg",
                    PictureUrl3 = "/images/products/Męska Ekstrawagancja3.jpg",
                    Sex = "Male",
                    Brand = "Brand3",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Mistrz Męskości",
                    Description = "Perfumy Mistrz Męskości są stworzone dla współczesnych mężczyzn, którzy emanują pewnością siebie i siłą charakteru. Ich aromat jest intensywny, łączący nuty drzewne i przyprawowe. To zapach, który podkreśla męską siłę i elegancję.",
                    PictureUrl = "/images/products/Mistrz Męskości.jpg",
                    PictureUrl2 = "/images/products/Mistrz Męskości2.jpg",
                    PictureUrl3 = "/images/products/Mistrz Męskości3.jpg",
                    Sex = "Male",
                    Brand = "Brand4",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Mroczna Tajemnica",
                    Description = "Mroczna Tajemnica to perfumy dla tajemniczych dusz. Ich intensywny aromat emanuje enigmatycznym charakterem. Nuty głowy to czarna porzeczka i bergamotka, które wkrótce ustępują miejsca głębszym nutom serca, takim jak czerwona róża i paczula. Bazą tych perfum jest skóra i wetiweria, co nadaje im nieco drapieżnego charakteru. To zapach dla osób, które lubią odkrywać tajemnice i fascynujące historie.",
                    PictureUrl = "/images/products/Mroczna Tajemnica.jpg",
                    PictureUrl2 = "/images/products/Mroczna Tajemnica2.jpg",
                    PictureUrl3 = "/images/products/Mroczna Tajemnica3.jpg",
                    Sex = "Female",
                    Brand = "Brand4",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Mroźny Deszcz",
                    Description = "Mroźny Deszcz to perfumy, które przypominają świeżo spadający deszcz. Ich aromat jest odświeżający i oczyszczający. Nuty głowy to cytrusy i zielone liście, które otwierają zapach jak pierwsze krople deszczu. W sercu tych perfum znajduje się aromatyczna szałwia, a baza to drzewo cedrowe i piżmo, które dodają im trwałości. To zapach dla miłośników natury i świeżości deszczu.",
                    PictureUrl = "/images/products/Mroźny Deszcz.jpg",
                    PictureUrl2 = "/images/products/Mroźny Deszcz2.jpg",
                    PictureUrl3 = "/images/products/Mroźny Deszcz3.jpg",
                    Sex = "Uni",
                    Brand = "Brand4",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Nocne Marzenia",
                    Description = "Nocne Marzenia to perfumy, które inspirują do nocnych wyobrażeń i marzeń. Ich tajemniczy aromat jest subtelny, ale uwodzicielski. Nuty głowy to lawenda i bergamotka, które stopniowo przechodzą w nuty serca, takie jak irys i paczula. Bazą tych perfum jest wetiweria i wanilia, co nadaje im głębię i senną atmosferę. To zapach, który towarzyszy w nocnych podróżach w krainę snów.",
                    PictureUrl = "/images/products/Nocne Marzenia.jpg",
                    PictureUrl2 = "/images/products/Nocne Marzenia2.jpg",
                    PictureUrl3 = "/images/products/Nocne Marzenia3.jpg",
                    Sex = "Female",
                    Brand = "Brand4",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Podróżna Opowieść",
                    Description = "Podróżna Opowieść to perfumy inspirowane fascynującymi opowieściami podróżników. Ich aromat jest pełen przygody i tajemnicy odległych miejsc. Nuty głowy to cytrusy i przyprawy, które otwierają zapach jak pierwszy krok w nieznanych krajach. W sercu tych perfum znajdują się nuty kwiatowe i drzewne, a baza to piżmo i bursztyn. To zapach, który przenosi do światów pełnych przygód i niezapomnianych historii.",
                    PictureUrl = "/images/products/Podróżna Opowieść.jpg",
                    PictureUrl2 = "/images/products/Podróżna Opowieść2.jpg",
                    PictureUrl3 = "/images/products/Podróżna Opowieść3.jpg",
                    Sex = "Male",
                    Brand = "Brand4",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Seksowna Nuta",
                    Description = "Seksowna Nuta to perfumy, które emanują seksapilem i zmysłowością. Ich zapach jest uwodzicielski i intrygujący. Nuty głowy to bergamotka i czarna porzeczka, które otwierają zapach jak pierwszy flirt. W sercu tych perfum znajdują się nuty jaśminu i paczuli, a baza to ambra i wetiweria. To zapach, który podkreśla atrakcyjność i pewność siebie.",
                    PictureUrl = "/images/products/Seksowna Nuta.jpg",
                    PictureUrl2 = "/images/products/Seksowna Nuta2.jpg",
                    PictureUrl3 = "/images/products/Seksowna Nuta3.jpg",
                    Sex = "Female",
                    Brand = "Brand5",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Słoneczne Promienie",
                    Description = "Słoneczne Promienie to perfumy, które przeniosą Cię w słoneczny dzień pełen energii i radości. Ich lekki aromat jest pełen świeżości. Nuty głowy to soczysta pomarańcza i mandarynka, które otwierają zapach jak promienie słońca. W sercu tych perfum znajduje się kwiat pomarańczy, a baza to drzewo cedrowe i białe piżmo. To idealny zapach na letnie dni i beztroskie chwile.",
                    PictureUrl = "/images/products/Słoneczne Promienie.jpg",
                    PictureUrl2 = "/images/products/Słoneczne Promienie2.jpg",
                    PictureUrl3 = "/images/products/Słoneczne Promienie3.jpg",
                    Sex = "Female",
                    Brand = "Brand5",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Zachód Słońca",
                    Description = "Zachód Słońca to perfumy, które przypominają piękne zachody słońca nad horyzontem. Ich aromat jest romantyczny i pełen ciepła. Nuty głowy to pomarańcza i bergamotka, które otwierają zapach jak ostatnie promienie zachodzącego słońca. W sercu tych perfum znajdują się nuty kwiatowe, takie jak róża i fiołek, a baza to wanilia i białe piżmo. To zapach, który towarzyszy magicznym chwilom na końcu dnia.",
                    PictureUrl = "/images/products/Zachód Słońca.jpg",
                    PictureUrl2 = "/images/products/Zachód Słońca2.jpg",
                    PictureUrl3 = "/images/products/Zachód Słońca3.jpg",
                    Sex = "Uni",
                    Brand = "Brand5",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Zapach Wolności",
                    Description = "Zapach Wolności to perfumy, które symbolizują wolność i niezależność. Ich aromat jest świeży i pełen energii. Nuty głowy to cytrusy i zielona herbata, które otwierają zapach jak wolność w powietrzu. W sercu tych perfum znajdują się nuty kwiatowe, takie jak frezja i róża, a baza to drzewo cedrowe i piżmo. To zapach, który podkreśla ducha wolności i pewności siebie.",
                    PictureUrl = "/images/products/Zapach Wolności.jpg",
                    PictureUrl2 = "/images/products/Zapach Wolności2.jpg",
                    PictureUrl3 = "/images/products/Zapach Wolności3.jpg",
                    Sex = "Male",
                    Brand = "Brand5",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Złoty Deszcz",
                    Description = "Złoty Deszcz to perfumy z nutami luksusowego złota. Ich aromat jest pełen blasku i bogactwa. Nuty głowy to bergamotka i mandarynka, które otwierają zapach jak promienie słońca na złotych płatkach. W sercu tych perfum znajdują się nuty białego złota i róża, a baza to drzewo sandałowe i piżmo. To zapach, który emanuje luksusem i wyrafinowaniem.",
                    PictureUrl = "/images/products/Złoty Deszcz.jpg",
                    PictureUrl2 = "/images/products/Złoty Deszcz2.jpg",
                    PictureUrl3 = "/images/products/Złoty Deszcz3.jpg",
                    Sex = "Uni",
                    Brand = "Brand6",
                    Price = r.Next(20000, 50000)
                },
                new Product
                {
                    Name = "Zmysłowa Nuta",
                    Description = "Zmysłowa Nuta to perfumy, które emanują zmysłowością i elegancją. Ich aromat jest zmysłowy i uwodzicielski. Nuty głowy to bergamotka i czarna porzeczka, które otwierają zapach jak pierwsze spojrzenie. W sercu tych perfum znajdują się nuty kwiatowe, takie jak róża i frezja, a baza to piżmo i drzewo cedrowe. To zapach, który podkreśla zmysłowość i elegancję.",
                    PictureUrl = "/images/products/Zmysłowa Nuta.jpg",
                    PictureUrl2 = "/images/products/Zmysłowa Nuta2.jpg",
                    PictureUrl3 = "/images/products/Zmysłowa Nuta3.jpg",
                    Sex = "Female",
                    Brand = "Brand6",
                    Price = r.Next(20000, 50000)
                },
            };


            var InventoryItems = new List<InventoryItem>();     

            foreach (var item in Products)
            {
                InventoryItems.Add( new InventoryItem
                {
                    SizeMl = 200,
                    PricePercent = 170,
                    QuantityInStock = 300,
                    Product = item
                });
                InventoryItems.Add( new InventoryItem
                {
                    SizeMl = 100,
                    PricePercent = 100,
                    QuantityInStock = 300,
                    Product = item
                });
                InventoryItems.Add( new InventoryItem
                {
                    SizeMl = 50,
                    PricePercent = 70,
                    QuantityInStock = 300,
                    Product = item
                });
                InventoryItems.Add( new InventoryItem
                {
                    SizeMl = 30,
                    PricePercent = 50,
                    QuantityInStock = 300,
                    Product = item
                });
            }

            foreach (var item in InventoryItems)
            {
                context.InventoryItems.Add(item);
            }

            foreach (var item in Products)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();
        }
    }
}
