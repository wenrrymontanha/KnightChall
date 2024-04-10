using KnightChall.Domain.DBModels;
using KnightChall.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnightChall.Infra.Repository;
using FluentValidation;
using MongoDB.Bson;
using KnightChall.Domain.DTO;

namespace KnightChall.Service.Services
{
    public class KnightService : IKnightService
    {
        private readonly IBaseRepository _baseRepository;

        public KnightService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Knight Add(DTOKnight obj)
        {
            //Knight knight = _mapper.Map<Knight>(obj);
            Knight knight = new Knight();
            knight._id = ObjectId.GenerateNewId().ToString();
            knight.name = obj.name;
            knight.nickname = obj.nickname;
            knight.birthday = obj.birthday;
            knight.keyAttribute = obj.keyAttribute;
            knight.attributes = obj.attributes;
            knight.weapons = obj.weapons;
            _baseRepository.Insert(knight);
            return knight;
        }

        public void Delete(string id) => _baseRepository.Delete(id);

        public Knight GetId(string Id) 
        {
            Knight knight = _baseRepository.Select(Id).FirstOrDefault();
            if (knight == null)
            {
                return new Knight();
            }
            else
            {
                return knight;
            }
        }
        public IList<DTOKnightList> Get(string filter)
        {
            IList<Knight> knights = _baseRepository.Select(filter);
            IList<DTOKnightList> dtoKnightsList = new List<DTOKnightList>();
            foreach (var knight in knights)
            {
                DTOKnightList dtoKnightList = new DTOKnightList();
                dtoKnightList._id = knight._id;
                dtoKnightList.name = knight.name;
                dtoKnightList.age = CalcularIdade(knight.birthday);
                dtoKnightList.keyAttribute = knight.keyAttribute;
                dtoKnightList.weapons = CalcularQtdWeapons(knight.weapons);
                dtoKnightList.attack = CalcularAtaque(knight.keyAttribute, knight.attributes, knight.weapons).ToString();
                dtoKnightList.experience = CalcularExperiencia(dtoKnightList.age);
                dtoKnightsList.Add(dtoKnightList);
            }
            return dtoKnightsList;
        }

        private string CalcularQtdWeapons(List<Weapon> weapons)
        {
            int qtd = 0;
            foreach (Weapon weapon in weapons)
            {
                if (weapon.equipped==true)
                {
                    qtd++;
                }
            }
            return qtd.ToString();
        }

        private string CalcularExperiencia(string age)
        {
            double exp = 0;
            if(Int32.Parse(age) <= 7) return "0";    
            exp = Math.Floor((Int32.Parse(age) - 7) * Math.Pow(22,1.45));
            return exp.ToString();
        }

        private string CalcularIdade(string dataAsString)
        {
            DateTime dataNascimento;
            if (!DateTime.TryParse(dataAsString,out dataNascimento)) return "0";
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataAtual.Month < dataNascimento.Month || (dataAtual.Month == dataNascimento.Month && dataAtual.Day < dataNascimento.Day))
            {
                idade--;
            }

            return idade.ToString();
        }
        private int CalcularAtaque(string keyAttr, Attributes attributes,List<Weapon> weapons)
        {
            int weapMod = 0;
            weapMod = CalcularWeaponModifier(keyAttr,weapons);
            switch (keyAttr)
            {
                case "strength":
                    return 10 + CalcularModifier(attributes.strength) + weapMod;
                case "dexterity":
                    return 10 + CalcularModifier(attributes.dexterity) + weapMod;
                case "constitution":
                    return 10 + CalcularModifier(attributes.constitution) + weapMod;
                case "intelligence":
                    return 10 + CalcularModifier(attributes.intelligence) + weapMod;
                case "wisdom":
                    return 10 + CalcularModifier(attributes.wisdom) + weapMod;
                case "charisma":
                    return 10 + CalcularModifier(attributes.charisma) + weapMod;
                default:
                    return 0;
            }
        }

        private int CalcularWeaponModifier(string keyAttr, List<Weapon> weapons)
        {
            int mod = 0;
            foreach (Weapon weapon in weapons)
            {
                if (weapon.equipped == true && keyAttr == weapon.attr)
                {
                    mod += weapon.mod;
                }
            }
            return mod;
        }

        private int CalcularModifier(int value)
        {
            if (value <= 8)
            {
                return -2;
            }
            else if (9 <= value && value <= 10)
            {
                return -1;
            }
            else if (11 <= value && value <= 12)
            {
                return 0;
            }
            else if (13 <= value && value <= 15)
            {
                return 1;
            }
            else if (16 <= value && value <= 18)
            {
                return 2;
            }
            else if (19 <= value && value <= 20)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        public Knight Update(string id, string name)
        {
            _baseRepository.Update(id, name);
            return _baseRepository.Select(id).FirstOrDefault();
        }

    }
}
