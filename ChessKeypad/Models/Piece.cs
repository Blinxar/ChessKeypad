using ChessKeypad.Models.Moves;
using System.Collections.Generic;

namespace ChessKeypad.Models;

public record Piece(List<Move> ValidMoves);
