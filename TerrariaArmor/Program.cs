using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaArmor {
	class Program {
		#region Variables
			struct Armor {
				public string name;
				public int def;
				public int dmg;
				public int crit;
				public int cost;
				public int mp;
				public static Armor operator+(Armor l, Armor r) {
					Armor a = new Armor { name = l.name + ", " + r.name, def = l.def + r.def, dmg = l.dmg + r.dmg, crit = l.crit + r.crit,
						cost = l.cost + r.cost, mp = l.mp + r.mp }; return a;
				}
			};
			static Armor[] heads = new Armor[] {
				new Armor {name = "None", def = 0, dmg = 0, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Meteor", def = 5, dmg = 7, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Mining", def = 1, dmg = 0, crit = 0, cost = 0, mp = 0},
				new Armor {name = "WizardHat", def = 2, dmg = 15, crit = 0, cost = 0, mp = 0},
				new Armor {name = "MagicHat", def = 2, dmg = 7, crit = 7, cost = 0, mp = 0},
				new Armor {name = "Jungle", def = 5, dmg = 0, crit = 4, cost = 0, mp = 40},
			};
			static Armor[] chests = new Armor[] {
				new Armor {name = "None", def = 0, dmg = 0, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Meteor", def = 6, dmg = 7, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Robe", def = 3, dmg = 0, crit = 0, cost = 15, mp = 80},
				new Armor {name = "Gypsy", def = 2, dmg = 6, crit = 6, cost = 10, mp = 0},
				new Armor {name = "Jungle", def = 6, dmg = 0, crit = 4, cost = 0, mp = 20},
			};
			static Armor[] legs = new Armor[] {
				new Armor {name = "None", def = 0, dmg = 0, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Meteor", def = 5, dmg = 7, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Jungle", def = 6, dmg = 0, crit = 4, cost = 0, mp = 20},
			};
			static Armor[] sets = new Armor[] {
				new Armor {name = "None", def = 0, dmg = 0, crit = 0, cost = 0, mp = 0},
				new Armor {name = "Meteor", def = 0, dmg = 0, crit = 0, cost = 0, mp = 0},
				new Armor {name = "WizRobe", def = 0, dmg = 0, crit = 10, cost = 0, mp = 0},
				new Armor {name = "MagRobe", def = 0, dmg = 0, crit = 0, cost = 0, mp = 60},
				new Armor {name = "Jungle", def = 0, dmg = 0, crit = 0, cost = 16, mp = 0},
			};
			struct Spell {
				public string name;
				public int dmg;
				public double kb;
				public int mp;
				public int crit;
				public int ut;
			}
			static Spell[] spells = new Spell[] {
				new Spell { name = "Bee Gun", dmg = 9, kb = 0, mp = 5, crit = 4, ut = 12 },
				new Spell { name = "Flamelash", dmg = 40, kb = 6.5, mp = 12, crit = 4, ut = 19 },
				new Spell { name = "Serpent", dmg = 40, kb = 0, mp = 9, crit = 4, ut = 28 },
			};
			struct Enemy {
				public string name;
				public int def;
			}
			static Enemy[] enemies = new Enemy[] {
				new Enemy {name = "Dummy", def = 0},
				new Enemy {name = "Wraith", def = 30},
			};
		#endregion Variables
		static void Main(string[] args) {
			string txt = "Head, Chest, Legs, Def, %Dmg, %Crit, '-%Cost, '+MP, Set?, Weapon, Enemy, "+
				"Dmg, Dmg+12%, Dmg+24%, AvgDmg, AD+24%D, AD+12%DC, AD+24%C, " +
				"DPS, DPS+24%D, DPS+12%DC, DPS+24%C, DPTMP, DPTMP+24%D, DPTMP+12%DC, DPTMP+24%C, DPTMP+120MP\n";
			double v = 0.0;
			double d0 = 0.0, d1 = 0.0, d2 = 0.0;
			double c0 = 0.0, c1 = 0.0, c2 = 0.0;
			double ad0 = 0.0, ad1 = 0.0, ad2 = 0.0, ad3 = 0.0;
			double ut = 0.0, cost = 0.0, mp = 0.0;
			int def = 30;
			//Console.Write("Damage, Crit%, Speed, KB, MP");
			for(int i = 0 ; i < spells.Length ; i++) {
				spells[i].dmg = (int)Math.Round(spells[i].dmg * 1.15);
				spells[i].kb = spells[i].kb * 1.15;
				spells[i].mp = (int)Math.Round(spells[i].mp * 0.9);
				spells[i].crit = spells[i].crit + 5;
				spells[i].ut = (int)Math.Round(spells[i].ut * 0.9);
			}
			
			Armor a = new Armor(); bool set = false;
			//d0 = Math.Round(s.dmg * 1.15); s.dmg = (int)d0; // Mythical Damage
			//c0 = Math.Round(s.crit + 5.0); s.crit = (int)c0; // Mythical Crit
			//ut = Math.Round(s.ut * 0.9); s.ut = (int)ut; // Mythical Speed
			//mp = Math.Round(s.mp * 0.9); s.mp = (int)mp; // Mythical Mana Cost
			//a = heads[3] + chests[2] + legs[2]; Console.Write(a.name); Console.ReadKey(true);
			foreach(Enemy e in enemies) {
				foreach(Spell s in spells) {
					foreach(Armor l in legs) {
						foreach(Armor c in chests) {
							foreach(Armor h in heads) {
								a = h + c + l; set = false;
								if(h.name == "WizardHat" && (c.name == "Robe" || c.name == "Gypsy")) { set = true; a.crit += 10; }
								if(h.name == "MagicHat" && (c.name == "Robe" || c.name == "Gypsy")) { set = true; a.mp += 60; }
								if(h.name == "Jungle" && c.name == "Jungle" && l.name == "Jungle") { set = true; a.cost += 16; }

								txt += a.name + ", " + a.def + ", " + a.dmg / 100.0 + ", " + a.crit / 100.0 + ", "
									+ a.cost / 100.0 + ", " + a.mp + ", " + set + ", " + s.name + ", " + e.name + ", ";

								c0 = (s.crit + a.crit) / 100.0; c1 = c0 + 0.12; c2 = c1 + 0.12;
								d0 = Math.Floor(s.dmg * (1 + (a.dmg + 00) / 100.0)) - Math.Ceiling(e.def * 0.75); txt += d0 + ", "; // Dmg+12%
								d1 = Math.Floor(s.dmg * (1 + (a.dmg + 12) / 100.0)) - Math.Ceiling(e.def * 0.75); txt += d1 + ", "; // Dmg+12%
								d2 = Math.Floor(s.dmg * (1 + (a.dmg + 24) / 100.0)) - Math.Ceiling(e.def * 0.75); txt += d2 + ", "; // Dmg+24%
								ad0 = d0 * ((1 - c0) + 2 * c0); txt += ad0 + ", "; // AvgDmg
								ad1 = d2 * ((1 - c0) + 2 * c0); txt += ad1 + ", "; // AD+24%D
								ad2 = d1 * ((1 - c1) + 2 * c1); txt += ad2 + ", "; // AD+12%DC
								ad3 = d0 * ((1 - c2) + 2 * c2); txt += ad3 + ", "; // AD+24%C
								v = 60.0 / s.ut;
								txt += ad0 * v + ", "; // DPS
								txt += ad1 * v + ", "; // DPS+24%D
								txt += ad2 * v + ", "; // DPS+12%DC
								txt += ad3 * v + ", "; // DPS+24%C
								v = (200 + a.mp) / s.mp;
								txt += ad0 * v + ", "; // DPTMP
								txt += ad1 * v + ", "; // DPTMP+24%D
								txt += ad2 * v + ", "; // DPTMP+12%DC
								txt += ad3 * v + ", "; // DPTMP+24%C
								v = (320 + a.mp) / s.mp;
								txt += ad0 * v; // DPTMP+120MP


								txt += "\n";
							}
						}
					}
				}
			}
			System.IO.File.WriteAllText(@"E:\Shared\Terraria\Armor.csv", txt);


		}
	}
}
