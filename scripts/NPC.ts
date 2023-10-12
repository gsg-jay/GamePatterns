import { GameEntityBase } from ".";

export class NPC implements GameEntityBase {
  Respawn(): void {
    throw new Error("Method not implemented.");
  }
  Die(): void {
    throw new Error("Method not implemented.");
  }
  StopAllActivity(): void {
    throw new Error("Method not implemented.");
  }
  StartAction() {}
  NextAction() {}
  LoopAction() {}
  StopAction() {}
}
