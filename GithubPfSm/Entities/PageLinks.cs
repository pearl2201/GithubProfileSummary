
using System.Net.Http;
using System.Linq;
/**
* Page link class to be used to determine the links to other pages of request
* responses encoded in the current response. These will be present if the
* result set size exceeds the per page limit.
*/
public class PageLinks
{

    private const string DELIM_LINKS = ","; //$NON-NLS-1$

    private const string DELIM_LINK_PARAM = ";"; //$NON-NLS-1$

    private string first;
    private string last;
    private string next;
    private string prev;

    /**
	 * Parse links from executed method
	 *
	 * @param response
	 */
    public PageLinks(HttpResponseMessage response)
    {
        string linkHeader = response.Headers.Try("Link").FirstOrDefault();
        if (!string.IsNullOrEmpty(linkHeader))
        {
            string[] links = linkHeader.Split(DELIM_LINKS);
            foreach (string link in links)
            {
                string[] segments = link.Split(DELIM_LINK_PARAM);
                if (segments.Length < 2)
                    continue;

                string linkPart = segments[0].Trim();
                if (!linkPart.StartsWith("<") || !linkPart.EndsWith(">")) //$NON-NLS-1$ //$NON-NLS-2$
                    continue;
                linkPart = linkPart.Substring(1, linkPart.Length - 1);

                for (int i = 1; i < segments.Length; i++)
                {
                    string[] rel = segments[i].Trim().Split("="); //$NON-NLS-1$
                    if (rel.Length < 2 || !string.Equals("rel", rel[0], System.StringComparison.CurrentCultureIgnoreCase))
                        continue;

                    string relValue = rel[1];
                    if (relValue.StartsWith("\"") && relValue.EndsWith("\"")) //$NON-NLS-1$ //$NON-NLS-2$
                        relValue = relValue.Substring(1, relValue.Length - 1);

                    if (string.Equals("first", relValue, System.StringComparison.CurrentCultureIgnoreCase))
                        first = linkPart;
                    else if (string.Equals("last", relValue, System.StringComparison.CurrentCultureIgnoreCase))
                        last = linkPart;
                    else if (string.Equals("next", relValue, System.StringComparison.CurrentCultureIgnoreCase))
                        next = linkPart;
                    else if (string.Equals("prev", relValue, System.StringComparison.CurrentCultureIgnoreCase))
                        prev = linkPart;
                }
            }
        }
        else
        {
            next = response.Headers.GetValues("next").FirstOrDefault();
            last = response.Headers.GetValues("last").FirstOrDefault();
        }
    }

    /**
	 * @return first
	 */
    public string getFirst()
    {
        return first;
    }

    /**
	 * @return last
	 */
    public string getLast()
    {
        return last;
    }

    /**
	 * @return next
	 */
    public string getNext()
    {
        return next;
    }

    /**
	 * @return prev
	 */
    public string getPrev()
    {
        return prev;
    }
}