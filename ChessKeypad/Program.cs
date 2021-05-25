using ChessKeypad.Factories;
using ChessKeypad.Managers;
using ChessKeypad.Models.Enums;
using System;

var layoutFactory = new LayoutFactory();
var layout = layoutFactory.Get(LayoutType.PhoneKeypad);

var pieceFactory = new PieceFactory();
var pawn = pieceFactory.Get(PieceType.Pawn);
var rook = pieceFactory.Get(PieceType.Rook);
var knight = pieceFactory.Get(PieceType.Knight);
var bishop = pieceFactory.Get(PieceType.Bishop);
var queen = pieceFactory.Get(PieceType.Queen);
var king = pieceFactory.Get(PieceType.King);

var numberGenerator = new NumberGenerator();
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, pawn, 7)} permutations for pawns");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, rook, 7)} permutations for rooks");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, knight, 7)} permutations for knights");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, bishop, 7)} permutations for bishops");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, queen, 7)} permutations for queens");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, king, 7)} permutations for kings");