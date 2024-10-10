using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal static IReadOnlyList<Item> Items => _items;

    private static readonly IReadOnlyList<Item> _items =
        new List<Item>()
        {
            Item.Create(1, "Alien DNA Capsule").Value
            ,Item.Create(2, "Alien Protein").Value
            ,Item.Create(3, "Stinger Remains").Value
            ,Item.Create(4, "Hatcher Remains").Value
            ,Item.Create(5, "Hog Remains").Value
            ,Item.Create(6, "Mercer Sphere").Value
            ,Item.Create(7, "Somersloop").Value
            ,Item.Create(8, "Spitter Remains").Value
            ,Item.Create(9, "Bacon Agaric").Value
            ,Item.Create(10, "Beryl Nut").Value
            ,Item.Create(11, "Paleberry").Value
            ,Item.Create(12, "Cluster Nobelisk").Value
            ,Item.Create(13, "Explosive Rebar").Value
            ,Item.Create(14, "Gas Nobelisk").Value
            ,Item.Create(15, "Homing Rifle Ammo").Value
            ,Item.Create(16, "Iron Rebar").Value
            ,Item.Create(17, "Nobelisk").Value
            ,Item.Create(18, "Nuke Nobelisk").Value
            ,Item.Create(19, "Pulse Nobelisk").Value
            ,Item.Create(20, "Rifle Ammo").Value
            ,Item.Create(21, "Shatter Rebar").Value
            ,Item.Create(22, "Stun Rebar").Value  
            ,Item.Create(23, "Turbo Rifle Ammo").Value
            ,Item.Create(24, "Blade Runners").Value
            ,Item.Create(25, "Gas Mask").Value
            ,Item.Create(26, "Hazmat Suit").Value
            ,Item.Create(27, "Hoverpack").Value
            ,Item.Create(28, "Jetpack").Value
            ,Item.Create(29, "Parachute").Value
            ,Item.Create(30, "Computer").Value    
            ,Item.Create(31, "Crystal Oscillator").Value
            ,Item.Create(32, "Radio Control Unit").Value
            ,Item.Create(33, "Supercomputer").Value
            ,Item.Create(34, "Superposition Oscillator").Value
            ,Item.Create(35, "Black Powder").Value
            ,Item.Create(36, "Gas Filter").Value
            ,Item.Create(37, "Iodine-Infused Filter").Value
            ,Item.Create(38, "Smokeless Powder").Value
            ,Item.Create(39, "Empty Canister").Value
            ,Item.Create(40, "Empty Fluid Tank").Value
            ,Item.Create(41, "Packaged Alumina Solution").Value
            ,Item.Create(42, "Packaged Nitric Acid").Value
            ,Item.Create(43, "Packaged Nitrogen Gas").Value
            ,Item.Create(44, "Packaged Sulfuric Acid").Value
            ,Item.Create(45, "Packaged Water").Value
            ,Item.Create(46, "Pressure Conversion Cube").Value
            ,Item.Create(47, "AI Limiter").Value
            ,Item.Create(48, "Cable").Value
            ,Item.Create(49, "Circuit Board").Value
            ,Item.Create(50, "High-Speed Connector").Value
            ,Item.Create(51, "Quickwire").Value
            ,Item.Create(52, "Reanimated SAM").Value
            ,Item.Create(53, "SAM Fluctuator").Value
            ,Item.Create(54, "Wire").Value
            ,Item.Create(55, "Actual Snow").Value 
            ,Item.Create(56, "Blue FICSMAS Ornament").Value
            ,Item.Create(57, "Candy Cane").Value
            ,Item.Create(58, "Candy Cane Basher").Value
            ,Item.Create(59, "Copper FICSMAS Ornament").Value
            ,Item.Create(60, "Fancy Fireworks").Value
            ,Item.Create(61, "FICSMAS Bow").Value 
            ,Item.Create(62, "FICSMAS Decoration").Value
            ,Item.Create(63, "FICSMAS Gift").Value
            ,Item.Create(64, "FICSMAS Ornament Bundle").Value
            ,Item.Create(65, "FICSMAS Tree Branch").Value
            ,Item.Create(66, "FICSMAS Wonder Star").Value
            ,Item.Create(67, "Iron FICSMAS Ornament").Value
            ,Item.Create(68, "Red FICSMAS Ornament").Value
            ,Item.Create(69, "Snowball").Value
            ,Item.Create(70, "Sparkly Fireworks").Value
            ,Item.Create(71, "Sweet Fireworks").Value
            ,Item.Create(72, "Biomass").Value
            ,Item.Create(73, "Compacted Coal").Value
            ,Item.Create(74, "Leaves").Value
            ,Item.Create(75, "Mycelia").Value
            ,Item.Create(76, "Packaged Fuel").Value
            ,Item.Create(77, "Packaged Heavy Oil Residue").Value
            ,Item.Create(78, "Packaged Ionized Fuel").Value
            ,Item.Create(79, "Packaged Liquid Biofuel").Value
            ,Item.Create(80, "Packaged Oil").Value
            ,Item.Create(81, "Packaged Rocket Fuel").Value
            ,Item.Create(82, "Packaged Turbofuel").Value
            ,Item.Create(83, "Plutonium Fuel Rod").Value
            ,Item.Create(84, "Solid Biofuel").Value
            ,Item.Create(85, "Uranium Fuel Rod").Value
            ,Item.Create(86, "Wood").Value
            ,Item.Create(87, "Dark Matter Residue").Value
            ,Item.Create(88, "Excited Photonic Matter").Value
            ,Item.Create(89, "Ionized Fuel").Value
            ,Item.Create(90, "Nitrogen Gas").Value
            ,Item.Create(91, "Rocket Fuel").Value
            ,Item.Create(92, "Chainsaw").Value
            ,Item.Create(93, "Medicinal Inhaler").Value
            ,Item.Create(94, "Object Scanner").Value
            ,Item.Create(95, "Portable Miner").Value
            ,Item.Create(96, "Zipline").Value
            ,Item.Create(97, "Battery").Value
            ,Item.Create(98, "Cooling System").Value
            ,Item.Create(99, "Heat Sink").Value
            ,Item.Create(100, "Motor").Value
            ,Item.Create(101, "Rotor").Value
            ,Item.Create(102, "Stator").Value
            ,Item.Create(103, "Turbo Motor").Value
            ,Item.Create(104, "Aluminum Ingot").Value
            ,Item.Create(105, "Caterium Ingot").Value
            ,Item.Create(106, "Copper Ingot").Value
            ,Item.Create(107, "Ficsite Ingot").Value
            ,Item.Create(108, "Iron Ingot").Value
            ,Item.Create(109, "Steel Ingot").Value
            ,Item.Create(110, "Alumina Solution").Value
            ,Item.Create(111, "Crude Oil").Value
            ,Item.Create(112, "Dissolved Silica").Value
            ,Item.Create(113, "Fuel").Value
            ,Item.Create(114, "Heavy Oil Residue").Value
            ,Item.Create(115, "Liquid Biofuel").Value
            ,Item.Create(116, "Nitric Acid").Value
            ,Item.Create(117, "Sulfuric Acid").Value
            ,Item.Create(118, "Turbofuel").Value
            ,Item.Create(119, "Water").Value
            ,Item.Create(120, "Aluminum Scrap").Value
            ,Item.Create(121, "Concrete").Value
            ,Item.Create(122, "Copper Powder").Value
            ,Item.Create(123, "Petroleum Coke").Value
            ,Item.Create(124, "Polymer Resin").Value
            ,Item.Create(125, "Quartz Crystal").Value
            ,Item.Create(126, "Silica").Value
            ,Item.Create(127, "Electromagnetic Control Rod").Value
            ,Item.Create(128, "Encased Plutonium Cell").Value
            ,Item.Create(129, "Encased Uranium Cell").Value
            ,Item.Create(130, "Ficsonium").Value
            ,Item.Create(131, "Ficsonium Fuel Rod").Value
            ,Item.Create(132, "Non-Fissile Uranium").Value
            ,Item.Create(133, "Plutonium Pellet").Value
            ,Item.Create(134, "Bauxite").Value
            ,Item.Create(135, "Caterium Ore").Value
            ,Item.Create(136, "Coal").Value
            ,Item.Create(137, "Copper Ore").Value
            ,Item.Create(138, "Iron Ore").Value
            ,Item.Create(139, "Limestone").Value
            ,Item.Create(140, "Raw Quartz").Value
            ,Item.Create(141, "SAM").Value
            ,Item.Create(142, "Sulfur").Value
            ,Item.Create(143, "Uranium").Value
            ,Item.Create(144, "Adaptive Control Unit").Value
            ,Item.Create(145, "AI Expansion Server").Value
            ,Item.Create(146, "Assembly Director System").Value
            ,Item.Create(147, "Automated Wiring").Value
            ,Item.Create(148, "Ballistic Warp Drive").Value
            ,Item.Create(149, "Biochemical Sculptor").Value
            ,Item.Create(150, "Magnetic Field Generator").Value
            ,Item.Create(151, "Modular Engine").Value
            ,Item.Create(152, "Nuclear Pasta").Value
            ,Item.Create(153, "Smart Plating").Value
            ,Item.Create(154, "Thermal Propulsion Rocket").Value
            ,Item.Create(155, "Versatile Framework").Value
            ,Item.Create(156, "Alien Power Matrix").Value
            ,Item.Create(157, "Dark Matter Crystal").Value
            ,Item.Create(158, "Diamonds").Value
            ,Item.Create(159, "Neural-Quantum Processor").Value
            ,Item.Create(160, "Singularity Cell").Value
            ,Item.Create(161, "Time Crystal").Value
            ,Item.Create(162, "Blue Power Slug").Value
            ,Item.Create(163, "Factory Cart").Value
            ,Item.Create(164, "FICSIT Coupon").Value
            ,Item.Create(165, "Golden Factory Cart").Value
            ,Item.Create(166, "Power Shard").Value
            ,Item.Create(167, "Purple Power Slug").Value
            ,Item.Create(168, "Yellow Power Slug").Value
            ,Item.Create(169, "Alclad Aluminum Sheet").Value
            ,Item.Create(170, "Aluminum Casing").Value
            ,Item.Create(171, "Copper Sheet").Value
            ,Item.Create(172, "Encased Industrial Beam").Value
            ,Item.Create(173, "Fabric").Value
            ,Item.Create(174, "Ficsite Trigon").Value
            ,Item.Create(175, "Fused Modular Frame").Value
            ,Item.Create(176, "Heavy Modular Frame").Value
            ,Item.Create(177, "Iron Plate").Value
            ,Item.Create(178, "Iron Rod").Value
            ,Item.Create(179, "Modular Frame").Value
            ,Item.Create(180, "Plastic").Value
            ,Item.Create(181, "Reinforced Iron Plate").Value
            ,Item.Create(182, "Rubber").Value
            ,Item.Create(183, "Screw").Value
            ,Item.Create(184, "Steel Beam").Value
            ,Item.Create(185, "Steel Pipe").Value
            ,Item.Create(186, "Plutonium Waste").Value
            ,Item.Create(187, "Uranium Waste").Value
            ,Item.Create(188, "Nobelisk Detonator").Value
            ,Item.Create(189, "Rebar Gun").Value
            ,Item.Create(190, "Rifle").Value
            ,Item.Create(191, "Xeno-Basher").Value
            ,Item.Create(192, "Xeno-Zapper").Value
        };
}
