﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Cryptography;

namespace Azure.Storage
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Blob using clientside encryption.
    /// </summary>
    public class ClientSideEncryptionOptions
    {
        /// <summary>
        /// The version of clientside encryption to use.
        /// </summary>
        public ClientSideEncryptionVersion Version { get; }

        /// <summary>
        /// Required for upload operations.
        /// The key used to wrap the generated content encryption key.
        /// For more information, see https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption.
        /// </summary>
        public IKeyEncryptionKey KeyEncryptionKey { get; set; }

        /// <summary>
        /// Required for download operations.
        /// Fetches the correct key encryption key to unwrap the downloaded content encryption key.
        /// For more information, see https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption.
        /// </summary>
        public IKeyEncryptionKeyResolver KeyResolver { get; set; }

        /// <summary>
        /// Required for upload operations.
        /// The algorithm identifier to use when wrapping the content encryption key. This is passed into
        /// <see cref="IKeyEncryptionKey.WrapKey(string, ReadOnlyMemory{byte}, System.Threading.CancellationToken)"/>
        /// and its async counterpart.
        /// </summary>
        public string KeyWrapAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSideEncryptionOptions"/> class.
        /// </summary>
        /// <param name="version">The version of clientside encryption to use.</param>
        public ClientSideEncryptionOptions(ClientSideEncryptionVersion version)
        {
            Version = version;
        }

        /// <summary>
        /// Copy constructor to keep these options grouped in clients while stopping users from
        /// accidentally altering our configs out from under us.
        /// </summary>
        /// <param name="other"></param>
        internal ClientSideEncryptionOptions(ClientSideEncryptionOptions other)
        {
            Version = other.Version;
            KeyEncryptionKey = other.KeyEncryptionKey;
            KeyResolver = other.KeyResolver;
            KeyWrapAlgorithm = other.KeyWrapAlgorithm;
        }
    }
}
