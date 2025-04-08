using System;

namespace TextRPG
{
    // 기본 캐릭터 클래스
    public class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int AttackPower { get; set; }

        public Character(string name, int hp, int attack)
        {
            Name = name;
            MaxHP = hp;
            HP = hp;
            AttackPower = attack;
        }

        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name}이(가) {target.Name}에게 {AttackPower}의 데미지를 입혔습니다!");
            target.TakeDamage(AttackPower);
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name}의 남은 체력: {HP}/{MaxHP}");
        }

        public void Heal(int amount)
        {
            HP += amount;
            if (HP > MaxHP) HP = MaxHP;
            Console.WriteLine($"{Name}이(가) {amount}만큼 회복했습니다! 현재 체력: {HP}/{MaxHP}");
        }

        public bool IsDead()
        {
            return HP <= 0;
        }
    }

    // 플레이어 클래스 (Character 상속)
    public class Player : Character
    {
        public Player(string name) : base(name, 100, 20) { }

        public void Turn(Monster monster)
        {
            Console.WriteLine("\n당신의 턴입니다! 행동을 선택하세요:");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 회복");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Attack(monster);
                    break;
                case "2":
                    Heal(20);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 턴을 넘깁니다.");
                    break;
            }
        }
    }
    // 몬스터 클래스
    public class Monster : Character
    {
        public Monster(string name) : base(name, 80, 15) { }

        public void Turn(Player player)
        {
            Console.WriteLine($"\n{this.Name}의 턴입니다!");
            Attack(player);
        }
    }
    // 메인 게임 클래스
    class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== 텍스트 RPG 게임 시작 =====");
            Console.Write("플레이어 이름을 입력하세요: ");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);
            Monster monster = new Monster("고블린");

            Console.WriteLine($"\n{monster.Name}이(가) 나타났다!");

            while (!player.IsDead() && !monster.IsDead())
            {
                player.Turn(monster);
                if (monster.IsDead()) break;

                monster.Turn(player);
            }

            if (player.IsDead())
                Console.WriteLine("\n당신은 패배했습니다...");
            else
                Console.WriteLine($"\n{monster.Name}을(를) 처치했습니다! 승리!");
        }
    }
}
