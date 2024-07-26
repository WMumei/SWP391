using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelryProductionOrder.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewSeedBaseDesignData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BaseDesigns",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Type" },
                values: new object[,]
                {
                    { 5, null, "The perfect blend of classic and modern, this custom ring has a major wow factor: a 1.5ct oval pink diamond, surrounded by a classic halo of ideally cut Hearts and Arrows diamonds. Set in rose gold, this ring is feminine and romantic.", "\\Images\\7979-image-1612583658_1440x.jpg", "Pink Oval Diamond Halo Engagement Ring", "Company" },
                    { 6, null, "Our client wanted a symbolic heart necklace for his wife. We added two big diamonds, for the two of them, and seven accent diamonds to represent everyone in their family.", "\\Images\\87a248f457f2f0977135becb26dc43ce-img-1.webp", "Family Heart Pendant", "Company" },
                    { 7, null, "This custom engagement ring features a bi-colored blue and purple sapphire, and color enhanced purple diamonds, set into a five petal lotus design with black rhodium detailing. The shank is two intertwining stems, terminating in delicate leaves.", "\\Images\\0e225f328c462698e949123a76f73fd3-img-1_97a7a112-f7bf-4449-bfb5-4e1329e805dc.webp", "Lotus Purple Diamond & Sapphire Ring", "Company" },
                    { 8, null, "Ribbons of platinum twist around a round brilliant cut blue diamond and swirl around your finger, for a wonderfully unique solitaire design.", "\\Images\\Custom_Blue_Diamond_Swirl_Engagement_Ring_Platinum_Bezel_Set_C109875_1.webp", "Bezel Set Swirl Blue Diamond Engagement Ring", "Company" },
                    { 9, null, "A petite drop, these earrings feature trillion cut diamonds that point to round bezel set alexandrites, for a bold, geometric design.", "\\Images\\Custom_Trillion_Diamond_Alexandrite_Earrings_White_Gold_C111970-003_1.webp", "Diamond & Alexandrite Stud Earrings", "Company" },
                    { 10, null, "This three stone ring makes a statement, with a jawdropping bezel set emerald cut amethyst at its center. A diamond is set on either side in the yellow gold split shank.", "\\Images\\Custom_Yellow_Gold_Bezel_Set_Amethyst_Ring_C109170_2.webp", "Bezel Set Amethyst Ring", "Company" },
                    { 11, null, "This is a fun, modern fashion ring with a geometric design that can double as a mother's ring! It's a mother's ring with a twist - definitely not your typical mother's ring style. Stack them in any order, adding more rings to mix and match. This ring can be made in any metal with your choice of gemstones or diamonds.", "\\Images\\FR105-ladies-custom-mothers-ring-stackable-with-sapphire-and-emerald-yellow-gold_e24f839f-d6fd-4304-bd59-c17e12e871b3.webp", "Stackable fashion ring or mother's ring", "Company" },
                    { 12, null, "Looking for longer pearl earrings and finding a bunch of studs and short drops? You're not alone! Here's a pair of distinctive Tahitian pearl earring drops with an elegant, organic design.", "\\Images\\ER101-tahitian-pearls-trillion-sapphires-diamond-drop-earrings_09b1a9b1-0d3d-421c-af9a-029ca1ecb008.webp", "Tahitian Pearl and Sapphire Earrings", "Company" },
                    { 13, null, "With custom, you get to include multiple elements that mean something to you. This ring guard features an anchor and wings, set with a diamond and a ruby for a look that gleams with meaning.", "\\Images\\8067-image-1580068996_e1f67302-b0d6-43d9-9399-472e090e120d.webp", "Anchor and Wings Ring Guard", "Company" },
                    { 14, null, "This ring is a bold band with black diamonds that perfectly complement the white diamonds. A simple statement on its own, this ring is a unisex design.", "\\Images\\BAND103-Black-and-white-diamond-band_64789a11-0a58-48a4-90a9-46b2f10e850c.webp", "White and Black Diamond Band", "Company" },
                    { 15, null, "Branches of high polished yellow gold weave and overlap. Matte finished leaves are accented with milgrain, creating this organic wedding band.", "\\Images\\Custom_Yellow_Gold_Leaf_Woven_Wedding_Band_C108630_1_3540f942-ad41-4aa7-bc6e-1e1355167da8.webp", "Woven Leaf Wedding Band", "Company" },
                    { 16, null, "Lovely and dainty, these scalloped white gold wedding bands have tapered round diamonds set all the way around.", "\\Images\\Custom_Scalloped_Dainty_Eternity_Diamond_Wedding_Band_C115153_1_fb567c30-10ac-479f-bf34-600ae9d4af9a.webp", "Dainty Scalloped Diamond Eternity Wedding Band", "Company" },
                    { 17, null, "This delicate constellation inspired pearl and diamond chevron-style band was created to flank either side of a client's ring.", "\\Images\\3d045b12c6cc607bfd55bb60c91fe076-img-1_22ebbc37-1a14-4122-a6ca-e661d952b838.webp", "Diamond and Pearl Chevron Ring", "Company" },
                    { 18, null, "This custom ring features scattered flush set Hearts and Arrows diamonds, which are ideally cut to maximize sparkle. It's made out of our special heat treated platinum, which is a client favorite due to its extreme durability and natural white appearance.", "\\Images\\63874425ac7e06ac9bd4167b6d2cffb5-img-1_38bb76f1-aa9d-4a74-9ac6-d2a401feae4c.webp", "Platinum Etoile Style Diamond Band", "Company" },
                    { 19, null, "Perfectly matched princess cut diamonds fill out the channel setting flawlessly, framed by double milgrain details and scrolling filigree cutouts on the side. All topped off with an adorable yellow side diamond!", "\\Images\\BAND110-Channel-Set-Band-Yellow-Side-Diamond_8b9e4895-270f-4d13-9287-287258fb4ff3.webp", "Channel Set Band with Yellow Side Diamond", "Company" },
                    { 20, null, "Simple and elegant, this diamond band is timeless. Customizable with whatever color gold or stones you like, wear this band with your engagement ring or as a stackable ring that goes with everything!", "\\Images\\BAND102-rose_de568f71-762f-4de6-9d2d-93318ad72bbb.webp", "Rose gold diamond eternity band", "Company" },
                    { 21, null, "A swish of diamonds creates an open, asymmetrical chevron shape in yellow gold for this custom wedding band.", "\\Images\\Custom_Yellow_Gold_Diamond_Open_Chevron_Wedding_Band_C113156_2.webp", "Open Chevron Diamond Wedding Band", "Company" },
                    { 22, null, "A pear shaped diamond and sapphire come together at the center of this stunning Toi Et Moi ring. The band is open twists of yellow gold that shines beneath the center stones.", "\\Images\\Custom_Toi_Et_Moi_Sapphire___Diamond_Twist_Ring_C111202_1_2026636c-3f7e-4b2c-815a-83f9ed37e499.webp", "Pear Shaped Sapphire & Diamond Twist Toi Et Moi Ring", "Company" },
                    { 23, null, "This 14kt yellow gold family ring features colored diamond birthstones set in a fun and unique \"coil\" design that wraps around the finger. Make it yours by setting the birthstones of everyone in the family, or set it with clear white diamonds for a beautiful statement ring.", "\\Images\\89f7ed814c7ccd1af32d09d63cf03150-img-1_4ffe6193-4311-47f5-b54b-49afcb602d1d.webp", "Coiled Mother's Ring", "Company" },
                    { 24, null, "This custom geometric 14k yellow gold engagement ring features a bezel set diamond, surrounded by a hexagonal onyx, set on-point.", "\\Images\\da795683c5c20a96f7243c2d53b55bce-img-1_75211d5b-9e26-4605-865b-abd2a76436f8.webp", "Onyx and Diamond Hexagon Ring", "Company" },
                    { 25, null, "These custom white gold sparkling earrings feature Hearts and Arrows diamonds, pave set into crescent moon and star studs.", "\\Images\\1cc052e03723f9d206b59aa9ed7548d1-img-1_d7de0c8b-ded6-48e7-8626-84ea7255c192.webp", "Celestial Star and Moon Stud Earrings", "Company" },
                    { 26, null, "This captivating men's ring features a yellow gold fish against white gold mountains, bezel set with a garnet and a moonstone.", "\\Images\\Custom_Garnet___Moonstone_Mountain_Fish_Ring_C114994_1_dc85e0d6-ab1d-4dac-8d54-16daf7d79a64.webp", "Garnet & Moonstone Mountain Fish Ring", "Company" },
                    { 27, null, "We hand engraved a pattern on this yellow gold band based on our client's drawing: an ocean nightscape with rolling waves and twinkling stars.", "\\Images\\adc394e3ef66788c3ee5f53eb4727713-img-1_b063ac0b-af0c-4215-9969-5469ecd5e82c.webp", "Sea and Stars Ocean Nightscape Band", "Company" },
                    { 28, null, "Three round brilliant cut diamonds, all set in platinum with six prongs, make light glitter and dance.", "\\Images\\Custom_Three_Stone_Diamond_Engagement_Ring_Platinum_C106809_1.webp", "Platinum Three Stone Diamond Engagement Ring", "Company" },
                    { 29, null, "A 1.80ct trillion cut teal sapphire steals the show in this contemporary bypass wave ring with diamond accents.", "\\Images\\14493-image-1609295068_e14c0264-9533-429a-ac6c-6fafc3f4a184.webp", "Modern Teal Sapphire Trillion Engagement Ring", "Company" },
                    { 30, null, "Graduated pink, purple, and blue sapphire wrap around star sapphires, accented with pearls and diamonds to create a spectacular, one of a kind pendant. The backside features beautiful waves and swirls in rose gold.", "\\Images\\Custom_Graduated_Sapphire_Pearl___Diamond_Pendant_C113044_1_30550cf7-b8c1-4255-9f08-807cd25da78b.webp", "Graduated Star Sapphire Pendant", "Company" },
                    { 31, null, "A stunning emerald cut Brazilian alexandrite weighing 1.00ct, takes center stage in this one of a kind geometric pendant, accented with a trillion cut white diamond and three round teal diamonds.", "\\Images\\9371ce3f3abde2b5cb55d46361fda4f5-img-1.webp", "Geometric Alexandrite Necklace", "Company" },
                    { 32, null, "A classic style with a bold look, this three stone platinum ring features a princess cut Mozambique garnet  between two princess cut diamonds, all tied together with a euroshank!", "\\Images\\bbe2560e1ec98dd6962daab21429d47d-img-1_7b2fb8a6-6d85-4197-90c6-d91558c68280.webp", "Garnet Platinum Ring", "Company" },
                    { 33, null, "These beautiful earrings are part of a set with a matching pendant! Made using the client's stones, we designed this unique, freeform set in white gold. These earrings can be set with any gemstones or diamonds.", "\\Images\\ER104-Ruby-and-diamond-water-drop-earrings_00318228-da35-4d89-b817-f0d74c9f8bb9.webp", "Ruby and diamond water drop earrings", "Company" },
                    { 34, null, "This 14k white gold bypass swirl ring features a round blue star sapphire and heirloom diamonds.", "\\Images\\b4d5613ae690104bf388af17964be9a2-img-1_e13c8c38-1b59-42ae-a4a5-12ade79002cc.webp", "Star Sapphire Swirl Ring", "Company" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "BaseDesigns",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
