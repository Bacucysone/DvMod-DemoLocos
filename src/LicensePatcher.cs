
using System.Text;
using DV.LocoRestoration;
using DV.OriginShift;
using DV.RenderTextureSystem.BookletRender;
using DV.ThingTypes;
using HarmonyLib;
using UnityEngine;

namespace DvMod.DemoLocos;

[HarmonyPatch(typeof(StaticLicenseBookletRender), "GetStaticTemplatePaperData")]
public static class LicensePatcher {
    private static readonly Sprite emptySprite = Sprite.Create(Texture2D.whiteTexture, Rect.zero, Vector2.zero);
    private static string GetModelLoco(TrainCar tc) {
        switch (tc.carType) {
            case TrainCarType.LocoShunter:
            return "DE2";
            case TrainCarType.LocoSteamHeavy:
            return "S282";
            case TrainCarType.LocoS060:
            return "S060";
            case TrainCarType.LocoDH4:
            return "DH4";
            case TrainCarType.LocoDM3:
            return "DM3";
            case TrainCarType.LocoDiesel:
            return "DE6";
        }
        return "ERROR";
    }
    private static string PrintLocos(bool ProvidePrecisePosition) {
        StringBuilder toWrite = new();
        foreach (LocoRestorationController restController in LocoRestorationController.allLocoRestorationControllers) {
            TrainCar loco = Traverse.Create(restController).Field("loco").GetValue<TrainCar>();
            switch (restController.State) {
                case LocoRestorationController.RestorationState.S0_Initialized:
                case LocoRestorationController.RestorationState.S1_UnlockedRestorationLicense:
                case LocoRestorationController.RestorationState.S2_LocoUnblocked:
                Vector3 locoPosition = loco.transform.AbsolutePosition();
                toWrite.Append("A "+GetModelLoco(loco)+" has been sighted ");
                if (ProvidePrecisePosition)
                    toWrite.Append("at "+SpawnPoints.GetClosest(locoPosition));
                else
                    toWrite.Append("in station "+SpawnPoints.GetStation(locoPosition));
                toWrite.Append("\n");
                break;
                case LocoRestorationController.RestorationState.S3_RerailedCars:
                toWrite.Append("The "+GetModelLoco(loco)+" is arriving to the museum\n");
                break;
                case LocoRestorationController.RestorationState.S4_OnDestinationTrack:
                case LocoRestorationController.RestorationState.S5_PartOrdered:
                case LocoRestorationController.RestorationState.S6_PartPickedUp:
                case LocoRestorationController.RestorationState.S7_PartDelivered:
                case LocoRestorationController.RestorationState.S8_PartInstalled:
                toWrite.Append("The "+GetModelLoco(loco)+" is at the museum\n");
                break;
                case LocoRestorationController.RestorationState.S9_LocoServiced:
                case LocoRestorationController.RestorationState.S10_PaintJobDone:
                toWrite.Append("The " + GetModelLoco(loco) + " is all yours!\n");
                break;
            }   
        }
        return toWrite.ToString();
    }
    public static void Postfix(GeneralLicenseType_v2 ___generalLicense, ref TemplatePaperData[] __result) {
        GeneralLicenseType whereToHint = Main.settings!.WaitMuseum ? GeneralLicenseType.MuseumCitySouth : GeneralLicenseType.TrainDriver;
        if (___generalLicense != null && ___generalLicense.v1 == whereToHint) {
            TemplatePaperData NewPage = new LicenseTemplatePaperData(
                "Demonstrator locomotives hints",
                PrintLocos(Main.settings!.ProvidePrecisePosition),
                ___generalLicense.color,
                "",
                "",
                "",
                ___generalLicense.icon,
                emptySprite
            );
            __result = [__result[0], NewPage] ;
        }
    }
}