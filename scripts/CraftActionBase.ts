export class CraftActionBase {
  // Events
  OnCraftTargetSet;
  OnCheckCraftInventory;
  OnCombineItems;
  OnCraftStart;
  OnCraftEnd;

  // Methods
  CraftItem(): void {
    throw new Error("Method not implemented.");
  }
  CombineItems(): void {
    throw new Error("Method not implemented.");
  }
  CheckInventory(): void {
    throw new Error("Method not implemented");
  }
}
