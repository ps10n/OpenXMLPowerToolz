﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DocumentFormat.OpenXml.Packaging;

namespace OpenXmlPowerToolz
{
    public class RevisionAccepter
    {
        public static WmlDocument AcceptRevisions(WmlDocument document)
        {
            using (OpenXmlMemoryStreamDocument streamDoc = new OpenXmlMemoryStreamDocument(document))
            {
                using (WordprocessingDocument doc = streamDoc.GetWordprocessingDocument())
                {
                    AcceptRevisions(doc);
                }
                return streamDoc.GetModifiedWmlDocument();
            }
        }

        public static void AcceptRevisions(WordprocessingDocument doc)
        {
            RevisionProcessor.AcceptRevisions(doc);
        }

        public static bool PartHasTrackedRevisions(OpenXmlPart part)
        {
            return RevisionProcessor.PartHasTrackedRevisions(part);
        }

        public static bool HasTrackedRevisions(WmlDocument document)
        {
            return RevisionProcessor.HasTrackedRevisions(document);
        }

        public static bool HasTrackedRevisions(WordprocessingDocument doc)
        {
            return RevisionProcessor.HasTrackedRevisions(doc);
        }
    }
}
