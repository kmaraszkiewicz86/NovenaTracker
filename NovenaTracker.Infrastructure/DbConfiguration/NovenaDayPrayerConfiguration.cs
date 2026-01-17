using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Infrastructure.DbConfiguration;

/// <summary>
/// Entity configuration for NovenaDayPrayer entity
/// </summary>
public class NovenaDayPrayerConfiguration : IEntityTypeConfiguration<NovenaDayPrayer>
{
    public void Configure(EntityTypeBuilder<NovenaDayPrayer> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.NovenaId)
            .IsRequired();
            
        builder.Property(e => e.DayNumber)
            .IsRequired();
            
        builder.Property(e => e.PrayerText)
            .IsRequired()
            .HasColumnType("TEXT");
            
        builder.Property(e => e.PrayerTitle)
            .HasMaxLength(200);
        
        // Create index for efficient querying
        builder.HasIndex(e => new { e.NovenaId, e.DayNumber });
        
        // Seed prayers for the Venerable Wenanty Katarzyniec novena
        builder.HasData(
            new NovenaDayPrayer
            {
                Id = 1,
                NovenaId = 1,
                DayNumber = 0,
                PrayerTitle = "Modlitwa początkowa",
                PrayerText = "Boże w Trójcy Jedyny, bądź uwielbiony za wszelkie dobra, którymi napełniłeś sługę Twego Wenantego; on przez życie według rad ewangelicznych i gorliwą posługę kapłańską w Kościele stał się przykładem dla Twoich wiernych. Wynieś, Panie, tego sługę Twego na ołtarze, abyśmy lepiej mogli Tobie służyć, mnie zaś udziel łaski, o którą pokornie proszę za jego wstawiennictwem. Przez Chrystusa Pana naszego. Amen."
            },
            new NovenaDayPrayer
            {
                Id = 2,
                NovenaId = 1,
                DayNumber = 1,
                PrayerTitle = "Dzień 1 – Dobre życie",
                PrayerText = @"„Człowiekiem dobrym, cnotliwym można się stać tylko powoli, a więc nie należy odkładać poprawy życia na później – bo później może zabraknąć czasu. Przecież to niemożliwe, aby grzesznik, który całe życie swoje obrażał Pana Boga, aby on potem w jednej chwili zmienił się na łożu śmiertelnym, aby się wtedy od razu skruszył, nawrócił i odpokutował za swoje winy, otóż wszyscy młodzi i starzy, w jakimkolwiek jesteśmy wieku, mamy zacząć żyć dobrze, zaraz teraz nie od jutra"".

/o. Wenanty Katarzyniec, Kazanie na I Niedzielę Adwentu/

Co to znaczy żyć dobrze? Sługa Boży O. Wenanty Katarzyniec odpowiada na to pytanie swoim życiem. Dobrze żyć to zanurzyć się w Bogu. Dobrze żyć to tak przeżywać każdy kolejny dzień, by nie zabrakło w nim miejsca i czasu dla Boga.

Módlmy się:

Boże w Trójcy Jedyny, naucz nas nie odkładać dobrego życia na jutro. Naucz nas żyć dobrze dzisiaj, teraz. Przez Chrystusa Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 3,
                NovenaId = 1,
                DayNumber = 2,
                PrayerTitle = "Dzień 2 – Łaska",
                PrayerText = @"„Łaska poświęcająca to dar Boży. My sami własnymi siłami ani odrobiny jej sobie powiększyć nie możemy. Ale Bóg dobry pozwala, że my nasze dobre uczynki skłaniamy, by nam łaski swej udzielił. Dobre uczynki są tedy nowym środkiem do pomnożenia łaski. A jak one liczne, ileż to sposobności mamy codziennie, by jakiś dobry uczynek wypełnić.""

/o. Wenanty Katarzyniec, Kazanie na Niedzielę po Nowym Roku/

Dobre życie bez pomocy Boga, bez Jego przychylności – jednym słowem – bez Jego łaski, byłoby niemożliwe. Bóg jest w nas źródłem „chcenia i działania zgodnie z Jego wolą"" (por. Flp 2,13). Bóg jest źródłem każdego dobra, każdego dobrego uczynku. Jeśli zapomnimy o tej prawdzie, zaczynamy upatrywać źródło mądrości i dobra tylko w sobie, a od tego już krok do upadku. O. Wenanty Katarzyniec nie zapomniał o tej prawdzie. Mocą łaski Bożej czynił dobro i niósł pociechę innym, nawet w trudnym czasie wojny.

Módlmy się:

Boże w Trójcy Jedyny, naucz nas szukać pomocy przede wszystkim w Twojej łasce i stwórz w nas serca pokorne, które wiedzą, że bez Ciebie nic nie możemy uczynić. Przez Chrystusa Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 4,
                NovenaId = 1,
                DayNumber = 3,
                PrayerTitle = "Dzień 3 – Unikanie grzechów",
                PrayerText = @"„Widzieliśmy mianowicie, iż grzech – to przekroczenie prawa, rozkazu Bożego, grzech to odmówienie posłuszeństwa Bogu – to bunt przeciw Niemu i otwarta wojna – grzech wreszcie to najczarniejsza niewdzięczność względem najlepszego naszego Ojca naszego i przyjaciela. (...) I któżby widząc tę złość grzechu, chciał jeszcze dalej grzeszyć? Od dzisiaj przeto, ile razy coś mamy robić, mówić lub myśleć, a sumienie przypomina, że to jest grzechem, że to Bogu się nie podoba, że to złe i niegodziwe, wzdrygnijmy się i zaniechajmy – lepiej wyrzec się wszelkiej przyjemności, lepiej wszystko wycierpieć niż zgrzeszyć, niż Boga obrazić, niż duszę swą splamić i haniebnie poniżyć! A gdy spostrzegamy, iż ktoś z bliźnich naszych brnie w grzechach, litujmy się nad nim, módlmy się za niego, ile sił mamy, przeszkadzajmy grzechowi!"".

/o. Wenanty Katarzyniec, Kazanie na Niedzielę zapustną/

Grzech jest zejściem z drogi do celu, którym jest Niebo. Oddala nas od kochającego Ojca, który jest spragniony naszych ramion. On czeka na nas zawsze z białą szatą dziecka Bożego. O. Wenanty znał serce Ojca, dlatego sam wolał cierpieć, niż zgrzeszyć i obrazić Jego Majestat.

Módlmy się: 

Boże w Trójcy Jedyny, prosimy dzisiaj o wolność od grzechu. A gdy upadniemy prosimy o łaskę jak najszybszego zwrócenia się do Ciebie. Przez Chrystusa Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 5,
                NovenaId = 1,
                DayNumber = 4,
                PrayerTitle = "Dzień 4 – Cierpienie",
                PrayerText = @"„Wielkim bardzo Pan Bóg obdarza nas dobrodziejstwem, kiedy nam grzechu odpuszcza; przywraca duszy naszej utraconą piękność, uwalnia od piekła, otwiera nam niebo, z niewolników czyni nas swemi ukochanemi dziećmi. Za tyle dobroci okazanej nam niegodnym – mielibyśmy jeszcze narzekać, kiedy nam Bóg każe coś cierpieć przez kilka chwil życia ziemskiego? O nie mówmy nigdy odtąd w utrapieniach swoich: Za co ja to cierpię? Com zawinił, że mnie tak ciężko Bóg dotyka. Raczej niech z ust naszych wychodzą takie: Panie najłaskawszy! Uginam się pod krzyżem cierpienia, ależ ja na większą karę zasłużyłem. Dzięki Ci Boże, że tak mało mi cierpieć każesz. Daj mi łaskę, abym wszystek dług Tobie na tej ziemi oddał, tak iżbym bez przeszkody mógł wejść po śmierci do Twego królestwa w niebie"".

/o. Wenanty Katarzyniec, Kazanie na V Niedzielę Wielkiego Postu/

Życie z Bogiem ciągle nas zaskakuje. Obfituje w szereg zwrotów i scenariuszy, których sami nigdy byśmy nie wybrali. Buntujemy się, kiedy pojawia się cierpienie, choroba, odrzucenie przez innych, samotność. Pytamy wtedy Boga: Dlaczego ja? Nie ma tu łatwych odpowiedzi, poza jedną: Zaufaj Bogu! Codzienny krzyż cierpienia nie był obcy o. Wenantemu. Fizyczne i duchowe cierpienia, niezrozumienie ze strony bliźniego, to tylko niektóre przejawy tego krzyża w życiu Czcigodnego Sługi Bożego, które przyjmował z poddaniem się woli Bożej.

Módlmy się:

Boże w Trójcy Jedyny, prosimy o łaskę cierpliwego znoszenia codziennych cierpień i przeciwności, które przeżywane z Tobą, mają moc uszlachetniania naszego serca. Przez Chrystusa Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 6,
                NovenaId = 1,
                DayNumber = 5,
                PrayerTitle = "Dzień 5 – Wiara",
                PrayerText = @"„Wiara jest to cnota, która w nas sprawia, że uznajemy za prawdę to wszystko, co Bóg objawił, a Kościół św. katolicki podaje do wierzenia. Otóż kto ma tę cnotę wiary, kto silnie i głęboko jest przejęty prawdami, które Bóg nam objawił, ten posiada wielki skarb – temu już nawet obecne życie ziemskie jest znośniejsze i lżejsze"".(s.122)

/o. Wenanty Katarzyniec, Kazanie na XXIII Niedzielę po Świątkach/

Wiara to dar, który otrzymaliśmy na Chrzcie Świętym. Ten skarb wiary przypomina nam, że Bóg jest naszym Ojcem, a my Jego dziećmi. Wiara pobudza nas, byśmy w swoim życiu odnaleźli tę najprawdziwszą prawdę o sobie – tożsamość dziecka Bożego. Cnota wiary w sposób heroiczny zajaśniała w Słudze Bożym o. Wenantym Katarzyńcu, który jak dziecko wierzył we wszystko, co Bóg objawił mu o Sobie i o jego przeznaczeniu. Sam też stał się tym, który z pasją przekazywał wiarę innym.

Módlmy się:

Boże w Trójcy Jedyny, prosimy Cię, byśmy nie ustali w wierze, ale z troską starali się o jej rozwój. Przez Chrystusa Pana naszego Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 7,
                NovenaId = 1,
                DayNumber = 6,
                PrayerTitle = "Dzień 6 – Nadzieja",
                PrayerText = @"„Mieć nadzieję w Bogu tzn. spodziewać się, że otrzymamy to, co nam Pan Bóg obiecał. A cóż Pan Bóg nam obiecał? Niebo, szczęście wieczne po śmierci, a tutaj obiecał nam Bóg odpuszczenie grzechów i łaskę Swoją. Otóż wszyscy jak tu jesteśmy, mamy spodziewać się, że będziemy kiedyś w niebie, mamy spodziewać w każdej pokusie łaski Bożej tak, iż niepodobna abyśmy zgrzeszyli, jeśli tylko zgrzeszyć nie chcemy. Pan Bóg – jak mówi Pismo św. – wierny jest i nie dopuści kusić nas nad to co możemy. Nadto nadzieja chrześcijańska każe nam spodziewać się pomocy Bożej, a sprawach doczesnych, zwłaszcza jeśli modlimy się o co do Boga, ufajmy niezachwianie, że to otrzymamy. Obiecał bowiem Pan Jezus: „Wszystko o cobyście prosili w modlitwie, wierząc weźmiecie"". (Mat.XXI.22).

/o. Wenanty Katarzyniec, Kazanie na IV Niedzielę Wielkiego Postu/

Jak łatwo w życiu o zniechęcenie. Jak łatwo ustać w wierze. Nadzieja to cnota, która podtrzymuje wiarę i wznosi nasz wzrok ponad aktualnie przeżywane trudności w kierunku Nieba. Także cnota nadziei zajaśniała w o. Wenantym w sposób heroiczny, bo na sprawy ziemskie starał się patrzeć z perspektywy Boga.

Módlmy się:

Boże w Trójcy Jedyny, gorąco prosimy o nadzieję, byśmy w drodze do Ciebie nie ustali,  w trudnościach oczekiwali pociechy, a po dobrym życiu spotkania z Tobą w Niebie. Przez Chrystusa Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 8,
                NovenaId = 1,
                DayNumber = 7,
                PrayerTitle = "Dzień 7 – Modlitwa",
                PrayerText = @"„Oprócz należytego zachowania się wymaga od nas P. Jezus w Najśw. Sakramencie obecny, byśmy z Nim rozmawiali, modlili się do Niego. Smutnem byłoby to znakiem, gdybyśmy się nudzili wobec P. Jezusa. Z ludźmi łatwo nam rozmawiać godzinę i więcej, a ze Zbawicielem tak trudno? Nie wiecie, co mówić do Chrystusa P. A czyż żadnych potrzeb nie macie? Może troska was trapi jaka? Może kłopot w domu, może bieda, choroba wam dolega to wszystko trzeba P. Jezusowi przedstawić! Nieraz chcecie się użalić przed kim, aby wam się lżej zrobiło, pragniecie? Oto Chrystus utajony w ołtarzu najlepszym waszym przyjacielem. Żadnych niemasz potrzeb doczesnych? lecz może twoja w opłakanym znajduje się stanie? może leżysz w grzechach nałogowych? Kiedy więc przyjdziesz do kościoła, odezwij się do swego Pana: Jezus! ratuj mnie, bom nędzny, ulecz mnie, podźwignij mnie z grzechu? Niemasz żadnych potrzeb sam – módl się za drugich, za opuszczonych za świat cały – a tak nie będzie ci się nudziło w kościele i P. Jezus zadowolony będzie z twojej obecności"". (s.86)

/o. Wenanty Katarzyniec, Nauka w czasie Adoracji Najświętszego Sakramentu w Oktawie Bożego Ciała/

Prawdziwa modlitwa to spotkanie z prawdziwym Bogiem, z Tym który nas kocha. A autentyczną modlitwę cechuje dziecięca szczerość i prostota, która pozwala być zawsze sobą przed Bogiem i mówić Mu o wszystkim, co jest w naszym sercu. Częsta adoracja Najświętszego Sakramentu, długie wieczorne modlitwy w Kościele zdradzały tę właśnie dziecięcą ufność o. Wenantego do Tego, który Go wybrał i powołał.

Módlmy się:

Boże w Trójcy Jedyny, naucz nas się modlić. Pociągnij nas do siebie i udziel łaski szczerej i ufnej modlitwy. Przez Chrystusa Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 9,
                NovenaId = 1,
                DayNumber = 8,
                PrayerTitle = "Dzień 8 – Maryja",
                PrayerText = @"„Jedno dążenie i pragnienie ciągnie się jak złota nić przez całe życie Matki Najśw. a mianowicie w każdej i najdrobniejszej rzeczy wypełniać wolę Bożą we wszystkiem kierować się upodobaniem P. Boga. Boski Syn Maryi wyrzekł o Sobie: „Pokarmem moim jest, abym czynił wolę Tego, który mię posłał"" (Jan IV.34) i „ja, co się mu podoba, zawsze czynię"". Te słowa były także regułą życia Najśw. Panny. Stąd nie dopuściła się Ona najmniejszej niewierności względem Pana Boga, najdrobniejszej niedoskonałości i cienia nawet nie było opieszałości w służbie, którą Bogu była winna. Nikt ze stworzeń nie wykazał lepiej woli Bożej niż Ona. Przez takie życie wyłącznie dla Boga musiała Matka Najśw. prostą drogą dojść do Boga i najwyższe miejsce osiągnąć w niebie. Tak! Marya najlepszą cząstkę obrała"".

/o. Wenanty Katarzyniec, Kazanie na Wniebowzięcie NMP/

W życiu potrzebujemy dobrych wzorów. Bóg daje nam Maryję, której jedynym upodobaniem było podobać się Bogu. Dla o. Wenantego Maryja Niepokalana była wzorem wierności Bogu w zwykłych obowiązkach. Nie ma żadnych wątpliwości, że Jej posłuszeństwo budziło zachwyt Sługi Bożego. Dowodem na to jest serdeczna przyjaźń i wsparcie dla św. Maksymiliana Kolbego w szerzeniu idei czci Niepokalanej na całym świecie.

Módlmy się:

Boże w Trójcy Jedyny, Ty dałeś nam w Maryi doskonały wzór wierności Twojej świętej woli, która jak złota nić objęła całe Jej życie. Spraw prosimy, abyśmy jak Maryja pragnęli zawsze podobać się Tobie. Przez Chrystusa, Pana naszego. Amen.

Ojcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu..."
            },
            new NovenaDayPrayer
            {
                Id = 10,
                NovenaId = 1,
                DayNumber = 9,
                PrayerTitle = "Dzień 9 – Niebo",
                PrayerText = @"„I dla nas wszystkich, Najmilsi, przydałoby się bardzo ujrzeć choć odrobinę, choć skrawek nieba, tego miejsca, gdzie Święci i Aniołowie z Bogiem królują. Lecz któż nam odsłoni to niebo? Oczyma ciała nie będziemy mogli zaglądnąć do niebieskich przybytków, ale za pomocą wiary wolno już nie na cząstkę nieba, lecz na całe szczęście w niebie patrzeć. Za pomocą wiary patrzeć w niebo tzn. rozważać o niebie, rozmyślać według wiary naszej św. według nauki Kościoła katolickiego. Rozważanie to o niebie wielce nam przydatnem będzie, abyśmy mogli wytrwać w tych czasach smutnych, abyśmy te utrapienie wszystkie umieli znieść mężnie, po chrześcijańsku"". (s. 56)

/o. Wenanty Katarzyniec, Kazanie na II Niedzielę Wielkiego Postu/

Niebo to upragniony cel ziemskiego życia, zwieńczenie dobrego życia na ziemi. Rozważanie o niebie było ważną częścią w nauczaniu Sługi Bożego o. Wenantego Katarzyńca. Pobudzić do częstego wznoszenia myśli do Boga, poznać skrawek Nieba już tu na ziemi – oto cel jego nauczania.

Módlmy się:

Boże w Trójcy Jedyny, Ty powiedziałeś, że Twoje Królestwo jest pośród nas (por Łk 17,21). Naucz nas dostrzegać znaki Twojej obecności na ziemi i uczyń nas godnymi oglądania Cię w pełni, w Niebie. Przez Chrystusa Pana naszego. Amen

Na zakończenie każdego dnia nowenny:

Ojcze nasz... Zdrowaś Maryjo... Chwała Ojcu..."
            }
        );
    }
}
