using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GithubPfSm.Entities
{
    public class Verification
    {
        public Verification() { }

        public Verification(bool verified, string reason, string signature, string payload)
        {
            Verified = verified;
            Reason = reason;
            Signature = signature;
            Payload = payload;
        }

        /// <summary>
        /// Does GitHub consider the signature in this commit to be verified?
        /// </summary>
        public bool Verified { get; protected set; }

        /// <summary>
        /// The reason for verified value.
        /// </summary>
        public string Reason { get; protected set; }

        /// <summary>
        /// The signature that was extracted from the commit.
        /// </summary>
        public string Signature { get; protected set; }

        /// <summary>
        /// The value that was signed.
        /// </summary>
        public string Payload { get; protected set; }

        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(
                     CultureInfo.InvariantCulture,
                     "Verification: {0} Verified: {1} Reason: {2} Signature: {3} Payload",
                     Verified,
                     Reason.ToString(),
                     Signature,
                     Payload);
            }
        }
    }

    public enum VerificationReason
    {
        [EnumMember(Value = "expired_key")]
        ExpiredKey,

        [EnumMember(Value = "not_signing_key")]
        NotSigningKey,

        [EnumMember(Value = "gpgverify_error")]
        GpgVerifyError,

        [EnumMember(Value = "gpgverify_unavailable")]
        GpgVerifyUnavailable,

        [EnumMember(Value = "unsigned")]
        Unsigned,

        [EnumMember(Value = "unknown_signature_type")]
        UnknownSignatureType,

        [EnumMember(Value = "no_user")]
        NoUser,

        [EnumMember(Value = "unverified_email")]
        UnverifiedEmail,

        [EnumMember(Value = "bad_email")]
        BadEmail,

        [EnumMember(Value = "unknown_key")]
        UnknownKey,

        [EnumMember(Value = "malformed_signature")]
        MalformedSignature,

        [EnumMember(Value = "inavlid")]
        Invalid,

        [EnumMember(Value = "valid")]
        Valid
    }
}
