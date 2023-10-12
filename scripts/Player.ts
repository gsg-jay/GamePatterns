import { CombatantBase, GameEntityBase, GamePlayerBase } from ".";

export class Player
  implements
    GameEntityBase,
    GamePlayerBase,
    CombatantBase,
    PlatformerBase,
    GunActionBase,
    MeleeActionBase,
    CraftActionBase,
{
  Respawn(): void {
    throw new Error("Method not implemented.");
  }
  StopAllActivity(): void {
    throw new Error("Method not implemented.");
  }
  OnJuggle(): void {
    throw new Error("Method not implemented.");
  }
  OnTakeDamage(): void {
    throw new Error("Method not implemented.");
  }
  OnTakeImpact(): void {
    throw new Error("Method not implemented.");
  }
  Juggle(): void {
    throw new Error("Method not implemented.");
  }
  TakeDamage(): void {
    throw new Error("Method not implemented.");
  }
  TakeImpact(): void {
    throw new Error("Method not implemented.");
  }
  Die(): void {
    throw new Error("Method not implemented.");
  }
  ListenForInput(): void {
    throw new Error("Method not implemented.");
  }
  LeaveGame(): void {
    throw new Error("Method not implemented.");
  }
  JoinGame(): void {
    throw new Error("Method not implemented.");
  }
  SignIn(): void {
    throw new Error("Method not implemented.");
  }
  SignOut(): void {
    throw new Error("Method not implemented.");
  }
  FreezeControls(): void {
    throw new Error("Method not implemented.");
  }
}
