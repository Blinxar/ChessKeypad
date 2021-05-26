using ChessKeypad.Factories;
using ChessKeypad.Managers;
using ChessKeypad.Models.Enums;
using ChessKeypad.Models.Layouts;
using System;

var layout = new KeypadLayout();

var pieceFactory = new ChessPieceFactory();
var pawn = pieceFactory.Get(ChessPiece.Pawn);
var rook = pieceFactory.Get(ChessPiece.Rook);
var knight = pieceFactory.Get(ChessPiece.Knight);
var bishop = pieceFactory.Get(ChessPiece.Bishop);
var queen = pieceFactory.Get(ChessPiece.Queen);
var king = pieceFactory.Get(ChessPiece.King);

var numberGenerator = new PermutationsGenerator();
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, pawn, 7)} permutations for pawns");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, rook, 7)} permutations for rooks");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, knight, 7)} permutations for knights");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, bishop, 7)} permutations for bishops");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, queen, 7)} permutations for queens");
Console.WriteLine($"There are {numberGenerator.CalculatePermutations(layout, king, 7)} permutations for kings");