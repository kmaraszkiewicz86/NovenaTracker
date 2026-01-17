using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovenaTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedWenantyNovenaWithFullPrayerTexts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Novenas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DaysDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novenas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NovenaDayPrayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NovenaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PrayerText = table.Column<string>(type: "TEXT", nullable: false),
                    PrayerTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovenaDayPrayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovenaDayPrayers_Novenas_NovenaId",
                        column: x => x.NovenaId,
                        principalTable: "Novenas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NovenaCompletions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NovenaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NovenaDayPrayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovenaCompletions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovenaCompletions_NovenaDayPrayers_NovenaDayPrayerId",
                        column: x => x.NovenaDayPrayerId,
                        principalTable: "NovenaDayPrayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NovenaCompletions_Novenas_NovenaId",
                        column: x => x.NovenaId,
                        principalTable: "Novenas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Novenas",
                columns: new[] { "Id", "DaysDuration", "Description", "Title" },
                values: new object[] { 1, 9, "Nowenna do Wenantego Katarzyńca to 9-dniowa modlitwa (nowenna od łac. novem - dziewięć), przez którą wierni proszą o łaski za wstawiennictwem Sługi Bożego o. Wenantego, franciszkanina, często w intencjach związanych z pracą, finansami i trudnymi sprawami, a także za dusze w czyśćcu cierpiące, gdyż sam o. Wenanty był ich gorliwym orędownikiem.", "Dziewięciodniowa nowenna za wstawiennictwem Sługi Bożego o.Wenantego Katarzyńca" });

            migrationBuilder.InsertData(
                table: "NovenaDayPrayers",
                columns: new[] { "Id", "DayNumber", "NovenaId", "PrayerText", "PrayerTitle" },
                values: new object[,]
                {
                    { 1, 0, 1, "Boże w Trójcy Jedyny, bądź uwielbiony za wszelkie dobra, którymi napełniłeś sługę Twego Wenantego; on przez życie według rad ewangelicznych i gorliwą posługę kapłańską w Kościele stał się przykładem dla Twoich wiernych. Wynieś, Panie, tego sługę Twego na ołtarze, abyśmy lepiej mogli Tobie służyć, mnie zaś udziel łaski, o którą pokornie proszę za jego wstawiennictwem. Przez Chrystusa Pana naszego. Amen.", "Modlitwa początkowa" },
                    { 2, 1, 1, "„Człowiekiem dobrym, cnotliwym można się stać tylko powoli, a więc nie należy odkładać poprawy życia na później – bo później może zabraknąć czasu. Przecież to niemożliwe, aby grzesznik, który całe życie swoje obrażał Pana Boga, aby on potem w jednej chwili zmienił się na łożu śmiertelnym, aby się wtedy od razu skruszył, nawrócił i odpokutował za swoje winy, otóż wszyscy młodzi i starzy, w jakimkolwiek jesteśmy wieku, mamy zacząć żyć dobrze, zaraz teraz nie od jutra\".\n\n/o. Wenanty Katarzyniec, Kazanie na I Niedzielę Adwentu/\n\nCo to znaczy żyć dobrze? Sługa Boży O. Wenanty Katarzyniec odpowiada na to pytanie swoim życiem. Dobrze żyć to zanurzyć się w Bogu. Dobrze żyć to tak przeżywać każdy kolejny dzień, by nie zabrakło w nim miejsca i czasu dla Boga.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, naucz nas nie odkładać dobrego życia na jutro. Naucz nas żyć dobrze dzisiaj, teraz. Przez Chrystusa Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 1 – Dobre życie" },
                    { 3, 2, 1, "„Łaska poświęcająca to dar Boży. My sami własnymi siłami ani odrobiny jej sobie powiększyć nie możemy. Ale Bóg dobry pozwala, że my nasze dobre uczynki skłaniamy, by nam łaski swej udzielił. Dobre uczynki są tedy nowym środkiem do pomnożenia łaski. A jak one liczne, ileż to sposobności mamy codziennie, by jakiś dobry uczynek wypełnić.\"\n\n/o. Wenanty Katarzyniec, Kazanie na Niedzielę po Nowym Roku/\n\nDobre życie bez pomocy Boga, bez Jego przychylności – jednym słowem – bez Jego łaski, byłoby niemożliwe. Bóg jest w nas źródłem „chcenia i działania zgodnie z Jego wolą\" (por. Flp 2,13). Bóg jest źródłem każdego dobra, każdego dobrego uczynku. Jeśli zapomnimy o tej prawdzie, zaczynamy upatrywać źródło mądrości i dobra tylko w sobie, a od tego już krok do upadku. O. Wenanty Katarzyniec nie zapomniał o tej prawdzie. Mocą łaski Bożej czynił dobro i niósł pociechę innym, nawet w trudnym czasie wojny.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, naucz nas szukać pomocy przede wszystkim w Twojej łasce i stwórz w nas serca pokorne, które wiedzą, że bez Ciebie nic nie możemy uczynić. Przez Chrystusa Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 2 – Łaska" },
                    { 4, 3, 1, "„Widzieliśmy mianowicie, iż grzech – to przekroczenie prawa, rozkazu Bożego, grzech to odmówienie posłuszeństwa Bogu – to bunt przeciw Niemu i otwarta wojna – grzech wreszcie to najczarniejsza niewdzięczność względem najlepszego naszego Ojca naszego i przyjaciela. (...) I któżby widząc tę złość grzechu, chciał jeszcze dalej grzeszyć? Od dzisiaj przeto, ile razy coś mamy robić, mówić lub myśleć, a sumienie przypomina, że to jest grzechem, że to Bogu się nie podoba, że to złe i niegodziwe, wzdrygnijmy się i zaniechajmy – lepiej wyrzec się wszelkiej przyjemności, lepiej wszystko wycierpieć niż zgrzeszyć, niż Boga obrazić, niż duszę swą splamić i haniebnie poniżyć! A gdy spostrzegamy, iż ktoś z bliźnich naszych brnie w grzechach, litujmy się nad nim, módlmy się za niego, ile sił mamy, przeszkadzajmy grzechowi!\".\n\n/o. Wenanty Katarzyniec, Kazanie na Niedzielę zapustną/\n\nGrzech jest zejściem z drogi do celu, którym jest Niebo. Oddala nas od kochającego Ojca, który jest spragniony naszych ramion. On czeka na nas zawsze z białą szatą dziecka Bożego. O. Wenanty znał serce Ojca, dlatego sam wolał cierpieć, niż zgrzeszyć i obrazić Jego Majestat.\n\nMódlmy się: \n\nBoże w Trójcy Jedyny, prosimy dzisiaj o wolność od grzechu. A gdy upadniemy prosimy o łaskę jak najszybszego zwrócenia się do Ciebie. Przez Chrystusa Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 3 – Unikanie grzechów" },
                    { 5, 4, 1, "„Wielkim bardzo Pan Bóg obdarza nas dobrodziejstwem, kiedy nam grzechu odpuszcza; przywraca duszy naszej utraconą piękność, uwalnia od piekła, otwiera nam niebo, z niewolników czyni nas swemi ukochanemi dziećmi. Za tyle dobroci okazanej nam niegodnym – mielibyśmy jeszcze narzekać, kiedy nam Bóg każe coś cierpieć przez kilka chwil życia ziemskiego? O nie mówmy nigdy odtąd w utrapieniach swoich: Za co ja to cierpię? Com zawinił, że mnie tak ciężko Bóg dotyka. Raczej niech z ust naszych wychodzą takie: Panie najłaskawszy! Uginam się pod krzyżem cierpienia, ależ ja na większą karę zasłużyłem. Dzięki Ci Boże, że tak mało mi cierpieć każesz. Daj mi łaskę, abym wszystek dług Tobie na tej ziemi oddał, tak iżbym bez przeszkody mógł wejść po śmierci do Twego królestwa w niebie\".\n\n/o. Wenanty Katarzyniec, Kazanie na V Niedzielę Wielkiego Postu/\n\nŻycie z Bogiem ciągle nas zaskakuje. Obfituje w szereg zwrotów i scenariuszy, których sami nigdy byśmy nie wybrali. Buntujemy się, kiedy pojawia się cierpienie, choroba, odrzucenie przez innych, samotność. Pytamy wtedy Boga: Dlaczego ja? Nie ma tu łatwych odpowiedzi, poza jedną: Zaufaj Bogu! Codzienny krzyż cierpienia nie był obcy o. Wenantemu. Fizyczne i duchowe cierpienia, niezrozumienie ze strony bliźniego, to tylko niektóre przejawy tego krzyża w życiu Czcigodnego Sługi Bożego, które przyjmował z poddaniem się woli Bożej.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, prosimy o łaskę cierpliwego znoszenia codziennych cierpień i przeciwności, które przeżywane z Tobą, mają moc uszlachetniania naszego serca. Przez Chrystusa Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 4 – Cierpienie" },
                    { 6, 5, 1, "„Wiara jest to cnota, która w nas sprawia, że uznajemy za prawdę to wszystko, co Bóg objawił, a Kościół św. katolicki podaje do wierzenia. Otóż kto ma tę cnotę wiary, kto silnie i głęboko jest przejęty prawdami, które Bóg nam objawił, ten posiada wielki skarb – temu już nawet obecne życie ziemskie jest znośniejsze i lżejsze\".(s.122)\n\n/o. Wenanty Katarzyniec, Kazanie na XXIII Niedzielę po Świątkach/\n\nWiara to dar, który otrzymaliśmy na Chrzcie Świętym. Ten skarb wiary przypomina nam, że Bóg jest naszym Ojcem, a my Jego dziećmi. Wiara pobudza nas, byśmy w swoim życiu odnaleźli tę najprawdziwszą prawdę o sobie – tożsamość dziecka Bożego. Cnota wiary w sposób heroiczny zajaśniała w Słudze Bożym o. Wenantym Katarzyńcu, który jak dziecko wierzył we wszystko, co Bóg objawił mu o Sobie i o jego przeznaczeniu. Sam też stał się tym, który z pasją przekazywał wiarę innym.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, prosimy Cię, byśmy nie ustali w wierze, ale z troską starali się o jej rozwój. Przez Chrystusa Pana naszego Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 5 – Wiara" },
                    { 7, 6, 1, "„Mieć nadzieję w Bogu tzn. spodziewać się, że otrzymamy to, co nam Pan Bóg obiecał. A cóż Pan Bóg nam obiecał? Niebo, szczęście wieczne po śmierci, a tutaj obiecał nam Bóg odpuszczenie grzechów i łaskę Swoją. Otóż wszyscy jak tu jesteśmy, mamy spodziewać się, że będziemy kiedyś w niebie, mamy spodziewać w każdej pokusie łaski Bożej tak, iż niepodobna abyśmy zgrzeszyli, jeśli tylko zgrzeszyć nie chcemy. Pan Bóg – jak mówi Pismo św. – wierny jest i nie dopuści kusić nas nad to co możemy. Nadto nadzieja chrześcijańska każe nam spodziewać się pomocy Bożej, a sprawach doczesnych, zwłaszcza jeśli modlimy się o co do Boga, ufajmy niezachwianie, że to otrzymamy. Obiecał bowiem Pan Jezus: „Wszystko o cobyście prosili w modlitwie, wierząc weźmiecie\". (Mat.XXI.22).\n\n/o. Wenanty Katarzyniec, Kazanie na IV Niedzielę Wielkiego Postu/\n\nJak łatwo w życiu o zniechęcenie. Jak łatwo ustać w wierze. Nadzieja to cnota, która podtrzymuje wiarę i wznosi nasz wzrok ponad aktualnie przeżywane trudności w kierunku Nieba. Także cnota nadziei zajaśniała w o. Wenantym w sposób heroiczny, bo na sprawy ziemskie starał się patrzeć z perspektywy Boga.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, gorąco prosimy o nadzieję, byśmy w drodze do Ciebie nie ustali,  w trudnościach oczekiwali pociechy, a po dobrym życiu spotkania z Tobą w Niebie. Przez Chrystusa Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 6 – Nadzieja" },
                    { 8, 7, 1, "„Oprócz należytego zachowania się wymaga od nas P. Jezus w Najśw. Sakramencie obecny, byśmy z Nim rozmawiali, modlili się do Niego. Smutnem byłoby to znakiem, gdybyśmy się nudzili wobec P. Jezusa. Z ludźmi łatwo nam rozmawiać godzinę i więcej, a ze Zbawicielem tak trudno? Nie wiecie, co mówić do Chrystusa P. A czyż żadnych potrzeb nie macie? Może troska was trapi jaka? Może kłopot w domu, może bieda, choroba wam dolega to wszystko trzeba P. Jezusowi przedstawić! Nieraz chcecie się użalić przed kim, aby wam się lżej zrobiło, pragniecie? Oto Chrystus utajony w ołtarzu najlepszym waszym przyjacielem. Żadnych niemasz potrzeb doczesnych? lecz może twoja w opłakanym znajduje się stanie? może leżysz w grzechach nałogowych? Kiedy więc przyjdziesz do kościoła, odezwij się do swego Pana: Jezus! ratuj mnie, bom nędzny, ulecz mnie, podźwignij mnie z grzechu? Niemasz żadnych potrzeb sam – módl się za drugich, za opuszczonych za świat cały – a tak nie będzie ci się nudziło w kościele i P. Jezus zadowolony będzie z twojej obecności\". (s.86)\n\n/o. Wenanty Katarzyniec, Nauka w czasie Adoracji Najświętszego Sakramentu w Oktawie Bożego Ciała/\n\nPrawdziwa modlitwa to spotkanie z prawdziwym Bogiem, z Tym który nas kocha. A autentyczną modlitwę cechuje dziecięca szczerość i prostota, która pozwala być zawsze sobą przed Bogiem i mówić Mu o wszystkim, co jest w naszym sercu. Częsta adoracja Najświętszego Sakramentu, długie wieczorne modlitwy w Kościele zdradzały tę właśnie dziecięcą ufność o. Wenantego do Tego, który Go wybrał i powołał.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, naucz nas się modlić. Pociągnij nas do siebie i udziel łaski szczerej i ufnej modlitwy. Przez Chrystusa Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 7 – Modlitwa" },
                    { 9, 8, 1, "„Jedno dążenie i pragnienie ciągnie się jak złota nić przez całe życie Matki Najśw. a mianowicie w każdej i najdrobniejszej rzeczy wypełniać wolę Bożą we wszystkiem kierować się upodobaniem P. Boga. Boski Syn Maryi wyrzekł o Sobie: „Pokarmem moim jest, abym czynił wolę Tego, który mię posłał\" (Jan IV.34) i „ja, co się mu podoba, zawsze czynię\". Te słowa były także regułą życia Najśw. Panny. Stąd nie dopuściła się Ona najmniejszej niewierności względem Pana Boga, najdrobniejszej niedoskonałości i cienia nawet nie było opieszałości w służbie, którą Bogu była winna. Nikt ze stworzeń nie wykazał lepiej woli Bożej niż Ona. Przez takie życie wyłącznie dla Boga musiała Matka Najśw. prostą drogą dojść do Boga i najwyższe miejsce osiągnąć w niebie. Tak! Marya najlepszą cząstkę obrała\".\n\n/o. Wenanty Katarzyniec, Kazanie na Wniebowzięcie NMP/\n\nW życiu potrzebujemy dobrych wzorów. Bóg daje nam Maryję, której jedynym upodobaniem było podobać się Bogu. Dla o. Wenantego Maryja Niepokalana była wzorem wierności Bogu w zwykłych obowiązkach. Nie ma żadnych wątpliwości, że Jej posłuszeństwo budziło zachwyt Sługi Bożego. Dowodem na to jest serdeczna przyjaźń i wsparcie dla św. Maksymiliana Kolbego w szerzeniu idei czci Niepokalanej na całym świecie.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, Ty dałeś nam w Maryi doskonały wzór wierności Twojej świętej woli, która jak złota nić objęła całe Jej życie. Spraw prosimy, abyśmy jak Maryja pragnęli zawsze podobać się Tobie. Przez Chrystusa, Pana naszego. Amen.\n\nOjcze nasz..., Zdrowaś Maryjo..., Chwała Ojcu...", "Dzień 8 – Maryja" },
                    { 10, 9, 1, "„I dla nas wszystkich, Najmilsi, przydałoby się bardzo ujrzeć choć odrobinę, choć skrawek nieba, tego miejsca, gdzie Święci i Aniołowie z Bogiem królują. Lecz któż nam odsłoni to niebo? Oczyma ciała nie będziemy mogli zaglądnąć do niebieskich przybytków, ale za pomocą wiary wolno już nie na cząstkę nieba, lecz na całe szczęście w niebie patrzeć. Za pomocą wiary patrzeć w niebo tzn. rozważać o niebie, rozmyślać według wiary naszej św. według nauki Kościoła katolickiego. Rozważanie to o niebie wielce nam przydatnem będzie, abyśmy mogli wytrwać w tych czasach smutnych, abyśmy te utrapienie wszystkie umieli znieść mężnie, po chrześcijańsku\". (s. 56)\n\n/o. Wenanty Katarzyniec, Kazanie na II Niedzielę Wielkiego Postu/\n\nNiebo to upragniony cel ziemskiego życia, zwieńczenie dobrego życia na ziemi. Rozważanie o niebie było ważną częścią w nauczaniu Sługi Bożego o. Wenantego Katarzyńca. Pobudzić do częstego wznoszenia myśli do Boga, poznać skrawek Nieba już tu na ziemi – oto cel jego nauczania.\n\nMódlmy się:\n\nBoże w Trójcy Jedyny, Ty powiedziałeś, że Twoje Królestwo jest pośród nas (por Łk 17,21). Naucz nas dostrzegać znaki Twojej obecności na ziemi i uczyń nas godnymi oglądania Cię w pełni, w Niebie. Przez Chrystusa Pana naszego. Amen\n\nNa zakończenie każdego dnia nowenny:\n\nOjcze nasz... Zdrowaś Maryjo... Chwała Ojcu...", "Dzień 9 – Niebo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovenaCompletions_NovenaDayPrayerId",
                table: "NovenaCompletions",
                column: "NovenaDayPrayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NovenaCompletions_NovenaId",
                table: "NovenaCompletions",
                column: "NovenaId");

            migrationBuilder.CreateIndex(
                name: "IX_NovenaDayPrayers_NovenaId_DayNumber",
                table: "NovenaDayPrayers",
                columns: new[] { "NovenaId", "DayNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovenaCompletions");

            migrationBuilder.DropTable(
                name: "NovenaDayPrayers");

            migrationBuilder.DropTable(
                name: "Novenas");
        }
    }
}
