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
			static Spell[] spells = new Spell[] { new Spell { name = "Flamelash", dmg = 40, kb = 6.5, mp = 12, crit = 4, ut = 19 } };
		#endregion Variables
		static void Main(string[] args) {
			string txt = "Head, Chest, Legs, Def, %Dmg, %Crit, '-%Cost, '+MP, Set?, "+
				"Dmg(FL), Dmg+24%, AvgDmg, AD+24%D, AD+24%C, DPS, DPTMP\n";
			//double v = 0.0;
			//Console.Write("Damage, Crit%, Speed, KB, MP");
			//for(int i = 0 ; i < spells.Length ; i++) {
			//	spells[i].dmg = (int)Math.Round(spells[i].dmg * 1.15);
			//	spells[i].kb = spells[i].kb * 1.15;
			//	spells[i].mp = (int)Math.Round(spells[i].dmg * 1.15);
			//	spells[i].dmg = (int)Math.Round(spells[i].dmg * 1.15);
			//	spells[i].dmg = (int)Math.Round(spells[i].dmg * 1.15);

			
			//}
			//System.IO.File.WriteAllText(@"E:\Shared\Terraria\Armor.csv");
			
			Armor a = new Armor(); Spell s = new Spell(); bool set = false;
			//a = heads[3] + chests[2] + legs[2]; Console.Write(a.name); Console.ReadKey(true);
			for(int l = 0 ; l < legs.Length ; l++) {
				for(int c = 0 ; c < chests.Length ; c++) {
					for(int h = 0 ; h < heads.Length ; h++) {
						a = heads[h] + chests[c] + legs[l]; set = false;
						if(heads[h].name == "WizardHat" && (chests[c].name == "Robe" || chests[c].name == "Gypsy"))
							{ set = true; a.crit += 10; }
						if(heads[h].name == "MagicHat" && (chests[c].name == "Robe" || chests[c].name == "Gypsy"))
							{ set = true; a.mp += 60; }
						if(heads[h].name == "Jungle" && chests[c].name == "Jungle" && legs[l].name == "Jungle")
							{ set = true; a.cost += 16; }

						txt += a.name + ", " + a.def + ", " + a.dmg / 100.0 + ", " + a.crit / 100.0 + ", "
							+ a.cost / 100.0 + ", " + a.mp + ", " + set;


					}
				}
			}


		}
	}
}
