﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GithubPfSm.Entities
{
   

    public class Committer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Committer"/> class.
        /// </summary>
        public Committer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Committer"/> class.
        /// </summary>
        /// <param name="name">The full name of the author or committer.</param>
        /// <param name="email">The email.</param>
        /// <param name="date">The date.</param>
        public Committer(string name, string email, DateTimeOffset date)
        {
            Name = name;
            Email = email;
            Date = date;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Committer"/> class.
        /// </summary>
        /// <param name="nodeId">The GraphQL Node Id</param>
        /// <param name="name">The full name of the author or committer.</param>
        /// <param name="email">The email.</param>
        /// <param name="date">The date.</param>
        public Committer(string nodeId, string name, string email, DateTimeOffset date)
        {
            NodeId = nodeId;
            Name = name;
            Email = email;
            Date = date;
        }

        /// <summary>
        /// GraphQL Node Id
        /// </summary>
        public string NodeId { get;  set; }

        /// <summary>
        /// Gets the name of the author or committer.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get;  set; }

        /// <summary>
        /// Gets the email of the author or committer.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get;  set; }

        /// <summary>
        /// Gets the date of the author or contributor's contributions.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTimeOffset Date { get;  set; }

        internal string DebuggerDisplay
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Name: {0} Email: {1} Date: {2}", Name, Email, Date); }
        }
    }
}
