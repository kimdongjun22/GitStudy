using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace mirror
{
    public class Game
    {
        private Player player;

        public void Start()
        {
            Initialize();
            Console.WriteLine("🔐 미로 방탈출 게임에 오신 것을 환영합니다!\n");

            while (true)
            {
                Console.WriteLine($"📍 현재 위치: {player.CurrentRoom.Name}");
                Console.WriteLine(player.CurrentRoom.Description);

                if (player.CurrentRoom.Puzzle != null && !player.CurrentRoom.IsPuzzleSolved)
                {
                    Console.WriteLine("🧩 퍼즐이 있습니다: " + player.CurrentRoom.Puzzle.Question);
                    Console.Write("정답 입력: ");
                    string answer = Console.ReadLine();
                    if (player.CurrentRoom.Puzzle.TrySolve(answer))
                    {
                        Console.WriteLine("✅ 정답입니다!");
                        player.CurrentRoom.IsPuzzleSolved = true;
                        player.Inventory.Add(new Item("열쇠", "문을 여는 열쇠"));
                    }
                    else
                    {
                        Console.WriteLine("❌ 틀렸습니다.");
                    }
                }

                Console.WriteLine("📦 아이템 확인 (I), 방향 이동 (북/남/동/서), 종료(Q)");
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (input.Equals("I", StringComparison.OrdinalIgnoreCase))
                {
                    player.ShowInventory();
                }
                else if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("게임을 종료합니다.");
                    break;
                }
                else
                {
                    if (!player.Move(input))
                    {
                        Console.WriteLine("❌ 이동할 수 없습니다.");
                    }

                    if (player.CurrentRoom.Name == "출구" &&
                        player.HasItem("열쇠"))
                    {
                        Console.WriteLine("🎉 열쇠로 문을 열고 탈출 성공!");
                        break;
                    }
                    else if (player.CurrentRoom.Name == "출구")
                    {
                        Console.WriteLine("🔒 열쇠가 없어 탈출할 수 없습니다.");
                    }
                }

                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            // 방 구성
            Room start = new Room("시작 방", "당신은 미로의 입구에 서 있습니다.");
            Room puzzleRoom = new Room("퍼즐 방", "퍼즐이 있는 방입니다.");
            Room keyRoom = new Room("아이템 방", "여기서 아이템을 얻을 수 있습니다.");
            Room exit = new Room("출구", "문이 굳게 닫혀 있습니다.");

            // 연결
            start.Connect("북", puzzleRoom);
            puzzleRoom.Connect("남", start);
            puzzleRoom.Connect("동", keyRoom);
            keyRoom.Connect("서", puzzleRoom);
            keyRoom.Connect("북", exit);
            exit.Connect("남", keyRoom);

            // 퍼즐
            puzzleRoom.Puzzle = new Puzzle("2 + 2 = ?", "4");

            // 아이템
            keyRoom.Items.Add(new Item("열쇠", "출구 문을 여는 열쇠"));

            // 플레이어
            player = new Player(start);
        }
    }
}
