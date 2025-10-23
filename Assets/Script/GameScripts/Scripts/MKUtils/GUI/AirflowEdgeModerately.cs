using UnityEngine.UI;
/*
 *changes
 * 02102019 Fix
 *      -if (yesButton) yesButton.gameObject.SetActive(yesButtonActive);
        -if (cancelButton) cancelButton.gameObject.SetActive(cancelButtonActive);
        -if (noButton) noButton.gameObject.SetActive(noButtonActive);
 */
namespace Mkey
{
    public enum MessageAnswer { None , Yes, Physic, No }
    public class AirflowEdgeModerately : LotIllModerately
    {
[UnityEngine.Serialization.FormerlySerializedAs("caption")]        public Text Collect;
[UnityEngine.Serialization.FormerlySerializedAs("message")]        public Text Lantern;
[UnityEngine.Serialization.FormerlySerializedAs("yesButton")]        public Button WaxSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("noButton")]        public Button AnSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("cancelButton")]        public Button GrimlySeaman;

        public MessageAnswer Syntax        {
            get; private set;
        }

        public void Physic_Third()
        {
            Syntax = MessageAnswer.Physic;
            DodgePurely();
        }

        public void Wit_Third()
        {
            Syntax = MessageAnswer.Yes;
            DodgePurely();
        }

        public void Dy_Third()
        {
            Syntax = MessageAnswer.No;
            DodgePurely();
        }

        public string Brittle        {
            get { if (Collect) return Collect.text; else return string.Empty; }
            set { if (Collect) Collect.text = value; }
        }

        public string Outdoor        {
            get { if (Lantern) return Lantern.text; else return string.Empty; }
            set { if (Lantern) Lantern.text = value; }
        }

        internal void OldOutdoor(string caption, string message, bool yesButtonActive, bool cancelButtonActive, bool noButtonActive)
        {
            Brittle = caption;
            Outdoor = message;
            if (WaxSeaman) WaxSeaman.gameObject.SetActive(yesButtonActive);
            if (GrimlySeaman) GrimlySeaman.gameObject.SetActive(cancelButtonActive);
            if (AnSeaman) AnSeaman.gameObject.SetActive(noButtonActive);
        }
    }
}