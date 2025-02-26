package at.sampas.personal_share;

import org.junit.jupiter.api.Test;

public class CreateShareTests {
    @Test
    public void TestOwnerCanCreateAShare() {
        Owner owner = getOwner();
        Share share = owner.createShare(new Name("testshare"));

        assertFalse(share.IsProtected());
        assertTrue(share.IsOwnedBy(owner));
    }

    @Test
    public void TestCreateShareWithFiles() {

    }

    @Test
    public void TestCreateShareFilesMustBelongToOwner() {
        Owner owner = getOwner();
        Share share = owner.createShare(new Name("testshare"));
    }
}
