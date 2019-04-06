/***************************************************************
* Copyright (C) 2011 Jeremy Reagan, All Rights Reserved.
* I may be reached via email at: jeremy.reagan@live.com
* 
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; under version 2
* of the License.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
****************************************************************/

using System.Collections.Generic;
using HL7Lib.Segments;

namespace HL7Lib.Base
{
    /// <summary>
    /// Enum of supported segments
    /// </summary>
    public enum Segments
    {
        ABS,
        ACC,
        ADD,
        AFF,
        AIG,
        AIL,
        AIP,
        AIS,
        AL1,
        APR,
        ARQ,
        AUT,
        BHS,
        BLC,
        BLG,
        BPO,
        BPX,
        BTS,
        BTX,
        CDM,
        CER,
        CM0,
        CM1,
        CM2,
        CNS,
        CON,
        CSP,
        CSR,
        CSS,
        CTD,
        CTI,
        DB1,
        DG1,
        DRG,
        DSC,
        DSP,
        ECD,
        ECR,
        EDU,
        EQL,
        EQP,
        EQU,
        ERQ,
        ERR,
        EVN,
        FAC,
        FHS,
        FT1,
        FTS,
        GOL,
        GP1,
        GP2,
        GT1,
        IAM,
        IIM,
        IN1,
        IN2,
        IN3,
        INV,
        IPC,
        ISD,
        LAN,
        LCC,
        LCH,
        LDP,
        LOC,
        LRL,
        MFA,
        MFE,
        MFI,
        MRG,
        MSA,
        MSH,
        NCK,
        NDS,
        NK1,
        NPU,
        NSC,
        NST,
        NTE,
        OBR,
        OBX,
        ODS,
        ODT,
        OM1,
        OM2,
        OM3,
        OM4,
        OM5,
        OM6,
        OM7,
        ORC,
        ORG,
        OVR,
        PCR,
        PD1,
        PDA,
        PDC,
        PEO,
        PES,
        PID,
        PR1,
        PRA,
        PRB,
        PRC,
        PRD,
        PSH,
        PTH,
        PV1,
        PV2,
        QAK,
        QID,
        QPD,
        QRD,
        QRF,
        QRI,
        RCP,
        RDF,
        RF1,
        RGS,
        RMI,
        ROL,
        RQ1,
        RQD,
        RXA,
        RXC,
        RXD,
        RXE,
        RXG,
        RXO,
        RXR,
        SAC,
        SCH,
        SFT,
        SID,
        SPM,
        SPR,
        STF,
        TCC,
        TCD,
        TQ1,
        TQ2,
        TXA,
        UB1,
        UB2,
        URD,
        URS,
        VAR,
        VTQ
    }
    /// <summary>
    /// Segment Class: Constructs an HL7 Segment Object
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// The Name of the Segment
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Segment Description
        /// </summary>
        public string Description { get; set; }     
        /// <summary>
        /// The Field List for the Segment
        /// </summary>
        public List<Field> Fields { get; set; }
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Segment() { }
        /// <summary>
        /// Constructs an HL7 segment for the specified Segments enum object
        /// </summary>
        /// <param name="seg">The Segments enum object to construct for</param>
        public Segment(Segments seg)
        {
            switch (seg)
            {
                case Segments.ABS:
                    ABS abs = new ABS();
                    Name = abs.Name;
                    Description = abs.Description;
                    Fields = abs.Fields;
                    break;
                case Segments.ACC:
                    ACC acc = new ACC();
                    Name = acc.Name;
                    Description = acc.Description;
                    Fields = acc.Fields;
                    break;
                case Segments.ADD:
                    ADD add = new ADD();
                    Name = add.Name;
                    Description = add.Description;
                    Fields = add.Fields;
                    break;
                case Segments.AFF:
                    AFF aff = new AFF();
                    Name = aff.Name;
                    Description = aff.Description;
                    Fields = aff.Fields;
                    break;
                case Segments.AIG:
                    AIG aig = new AIG();
                    Name = aig.Name;
                    Description = aig.Description;
                    Fields = aig.Fields;
                    break;
                case Segments.AIL:
                    AIL ail = new AIL();
                    Name = ail.Name;
                    Description = ail.Description;
                    Fields = ail.Fields;
                    break;
                case Segments.AIP:
                    AIP aip = new AIP();
                    Name = aip.Name;
                    Description = aip.Description;
                    Fields = aip.Fields;
                    break;
                case Segments.AIS:
                    AIS ais = new AIS();
                    Name = ais.Name;
                    Description = ais.Description;
                    Fields = ais.Fields;
                    break;
                case Segments.AL1:
                    AL1 al1 = new AL1();
                    Name = al1.Name;
                    Description = al1.Description;
                    Fields = al1.Fields;
                    break;
                case Segments.APR:
                    APR apr = new APR();
                    Name = apr.Name;
                    Description = apr.Description;
                    Fields = apr.Fields;
                    break;
                case Segments.ARQ:
                    ARQ arq = new ARQ();
                    Name = arq.Name;
                    Description = arq.Description;
                    Fields = arq.Fields;
                    break;
                case Segments.AUT:
                    AUT aut = new AUT();
                    Name = aut.Name;
                    Description = aut.Description;
                    Fields = aut.Fields;
                    break;
                case Segments.BHS:
                    BHS bhs = new BHS();
                    Name = bhs.Name;
                    Description = bhs.Description;
                    Fields = bhs.Fields;
                    break;
                case Segments.BLC:
                    BLC blc = new BLC();
                    Name = blc.Name;
                    Description = blc.Description;
                    Fields = blc.Fields;
                    break;
                case Segments.BLG:
                    BLG blg = new BLG();
                    Name = blg.Name;
                    Description = blg.Description;
                    Fields = blg.Fields;
                    break;
                case Segments.BPO:
                    BPO bpo = new BPO();
                    Name = bpo.Name;
                    Description = bpo.Description;
                    Fields = bpo.Fields;
                    break;
                case Segments.BPX:
                    BPX bpx = new BPX();
                    Name = bpx.Name;
                    Description = bpx.Description;
                    Fields = bpx.Fields;
                    break;
                case Segments.BTS:
                    BTS bts = new BTS();
                    Name = bts.Name;
                    Description = bts.Description;
                    Fields = bts.Fields;
                    break;
                case Segments.BTX:
                    BTX btx = new BTX();
                    Name = btx.Name;
                    Description = btx.Description;
                    Fields = btx.Fields;
                    break;
                case Segments.CDM:
                    CDM cdm = new CDM();
                    Name = cdm.Name;
                    Description = cdm.Description;
                    Fields = cdm.Fields;
                    break;
                case Segments.CER:
                    CER cer = new CER();
                    Name = cer.Name;
                    Description = cer.Description;
                    Fields = cer.Fields;
                    break;
                case Segments.CM0:
                    CM0 cm0 = new CM0();
                    Name = cm0.Name;
                    Description = cm0.Description;
                    Fields = cm0.Fields;
                    break;
                case Segments.CM1:
                    CM1 cm1 = new CM1();
                    Name = cm1.Name;
                    Description = cm1.Description;
                    Fields = cm1.Fields;
                    break;
                case Segments.CM2:
                    CM2 cm2 = new CM2();
                    Name = cm2.Name;
                    Description = cm2.Description;
                    Fields = cm2.Fields;
                    break;
                case Segments.CNS:
                    CNS cns = new CNS();
                    Name = cns.Name;
                    Description = cns.Description;
                    Fields = cns.Fields;
                    break;
                case Segments.CON:
                    CON con = new CON();
                    Name = con.Name;
                    Description = con.Description;
                    Fields = con.Fields;
                    break;
                case Segments.CSP:
                    CSP csp = new CSP();
                    Name = csp.Name;
                    Description = csp.Description;
                    Fields = csp.Fields;
                    break;
                case Segments.CSR:
                    CSR csr = new CSR();
                    Name = csr.Name;
                    Description = csr.Description;
                    Fields = csr.Fields;
                    break;
                case Segments.CSS:
                    CSS css = new CSS();
                    Name = css.Name;
                    Description = css.Description;
                    Fields = css.Fields;
                    break;
                case Segments.CTD:
                    CTD ctd = new CTD();
                    Name = ctd.Name;
                    Description = ctd.Description;
                    Fields = ctd.Fields;
                    break;
                case Segments.CTI:
                    CTI cti = new CTI();
                    Name = cti.Name;
                    Description = cti.Description;
                    Fields = cti.Fields;
                    break;
                case Segments.DB1:
                    DB1 db1 = new DB1();
                    Name = db1.Name;
                    Description = db1.Description;
                    Fields = db1.Fields;
                    break;
                case Segments.DG1:
                    DG1 dg1 = new DG1();
                    Name = dg1.Name;
                    Description = dg1.Description;
                    Fields = dg1.Fields;
                    break;
                case Segments.DRG:
                    DRG drg = new DRG();
                    Name = drg.Name;
                    Description = drg.Description;
                    Fields = drg.Fields;
                    break;
                case Segments.DSC:
                    DSC dsc = new DSC();
                    Name = dsc.Name;
                    Description = dsc.Description;
                    Fields = dsc.Fields;
                    break;
                case Segments.DSP:
                    DSP dsp = new DSP();
                    Name = dsp.Name;
                    Description = dsp.Description;
                    Fields = dsp.Fields;
                    break;
                case Segments.ECD:
                    ECD ecd = new ECD();
                    Name = ecd.Name;
                    Description = ecd.Description;
                    Fields = ecd.Fields;
                    break;
                case Segments.ECR:
                    ECR ecr = new ECR();
                    Name = ecr.Name;
                    Description = ecr.Description;
                    Fields = ecr.Fields;
                    break;
                case Segments.EDU:
                    EDU edu = new EDU();
                    Name = edu.Name;
                    Description = edu.Description;
                    Fields = edu.Fields;
                    break;
                case Segments.EQL:
                    EQL eql = new EQL();
                    Name = eql.Name;
                    Description = eql.Description;
                    Fields = eql.Fields;
                    break;
                case Segments.EQP:
                    EQP eqp = new EQP();
                    Name = eqp.Name;
                    Description = eqp.Description;
                    Fields = eqp.Fields;
                    break;
                case Segments.EQU:
                    EQU equ = new EQU();
                    Name = equ.Name;
                    Description = equ.Description;
                    Fields = equ.Fields;
                    break;
                case Segments.ERQ:
                    ERQ erq = new ERQ();
                    Name = erq.Name;
                    Description = erq.Description;
                    Fields = erq.Fields;
                    break;
                case Segments.ERR:
                    ERR err = new ERR();
                    Name = err.Name;
                    Description = err.Description;
                    Fields = err.Fields;
                    break;
                case Segments.EVN:
                    EVN evn = new EVN();
                    Name = evn.Name;
                    Description = evn.Description;
                    Fields = evn.Fields;
                    break;
                case Segments.FAC:
                    FAC fac = new FAC();
                    Name = fac.Name;
                    Description = fac.Description;
                    Fields = fac.Fields;
                    break;
                case Segments.FHS:
                    FHS fhs = new FHS();
                    Name = fhs.Name;
                    Description = fhs.Description;
                    Fields = fhs.Fields;
                    break;
                case Segments.FT1:
                    FT1 ft1 = new FT1();
                    Name = ft1.Name;
                    Description = ft1.Description;
                    Fields = ft1.Fields;
                    break;
                case Segments.FTS:
                    FTS fts = new FTS();
                    Name = fts.Name;
                    Description = fts.Description;
                    Fields = fts.Fields;
                    break;
                case Segments.GOL:
                    GOL gol = new GOL();
                    Name = gol.Name;
                    Description = gol.Description;
                    Fields = gol.Fields;
                    break;
                case Segments.GP1:
                    GP1 gp1 = new GP1();
                    Name = gp1.Name;
                    Description = gp1.Description;
                    Fields = gp1.Fields;
                    break;
                case Segments.GP2:
                    GP2 gp2 = new GP2();
                    Name = gp2.Name;
                    Description = gp2.Description;
                    Fields = gp2.Fields;
                    break;
                case Segments.GT1:
                    GT1 gt1 = new GT1();
                    Name = gt1.Name;
                    Description = gt1.Description;
                    Fields = gt1.Fields;
                    break;
                case Segments.IAM:
                    IAM iam = new IAM();
                    Name = iam.Name;
                    Description = iam.Description;
                    Fields = iam.Fields;
                    break;
                case Segments.IIM:
                    IIM iim = new IIM();
                    Name = iim.Name;
                    Description = iim.Description;
                    Fields = iim.Fields;
                    break;
                case Segments.IN1:
                    IN1 in1 = new IN1();
                    Name = in1.Name;
                    Description = in1.Description;
                    Fields = in1.Fields;
                    break;
                case Segments.IN2:
                    IN2 in2 = new IN2();
                    Name = in2.Name;
                    Description = in2.Description;
                    Fields = in2.Fields;
                    break;
                case Segments.IN3:
                    IN3 in3 = new IN3();
                    Name = in3.Name;
                    Description = in3.Description;
                    Fields = in3.Fields;
                    break;
                case Segments.INV:
                    INV inv = new INV();
                    Name = inv.Name;
                    Description = inv.Description;
                    Fields = inv.Fields;
                    break;
                case Segments.IPC:
                    IPC ipc = new IPC();
                    Name = ipc.Name;
                    Description = ipc.Description;
                    Fields = ipc.Fields;
                    break;
                case Segments.ISD:
                    ISD isd = new ISD();
                    Name = isd.Name;
                    Description = isd.Description;
                    Fields = isd.Fields;
                    break;
                case Segments.LAN:
                    LAN lan = new LAN();
                    Name = lan.Name;
                    Description = lan.Description;
                    Fields = lan.Fields;
                    break;
                case Segments.LCC:
                    LCC lcc = new LCC();
                    Name = lcc.Name;
                    Description = lcc.Description;
                    Fields = lcc.Fields;
                    break;
                case Segments.LCH:
                    LCH lch = new LCH();
                    Name = lch.Name;
                    Description = lch.Description;
                    Fields = lch.Fields;
                    break;
                case Segments.LDP:
                    LDP ldp = new LDP();
                    Name = ldp.Name;
                    Description = ldp.Description;
                    Fields = ldp.Fields;
                    break;
                case Segments.LOC:
                    LOC loc = new LOC();
                    Name = loc.Name;
                    Description = loc.Description;
                    Fields = loc.Fields;
                    break;
                case Segments.LRL:
                    LRL lrl = new LRL();
                    Name = lrl.Name;
                    Description = lrl.Description;
                    Fields = lrl.Fields;
                    break;
                case Segments.MFA:
                    MFA mfa = new MFA();
                    Name = mfa.Name;
                    Description = mfa.Description;
                    Fields = mfa.Fields;
                    break;
                case Segments.MFE:
                    MFE mfe = new MFE();
                    Name = mfe.Name;
                    Description = mfe.Description;
                    Fields = mfe.Fields;
                    break;
                case Segments.MFI:
                    MFI mfi = new MFI();
                    Name = mfi.Name;
                    Description = mfi.Description;
                    Fields = mfi.Fields;
                    break;
                case Segments.MRG:
                    MRG mrg = new MRG();
                    Name = mrg.Name;
                    Description = mrg.Description;
                    Fields = mrg.Fields;
                    break;
                case Segments.MSA:
                    MSA msa = new MSA();
                    Name = msa.Name;
                    Description = msa.Description;
                    Fields = msa.Fields;
                    break;
                case Segments.MSH:
                    MSH msh = new MSH();
                    Name = msh.Name;
                    Description = msh.Description;
                    Fields = msh.Fields;
                    break;
                case Segments.NCK:
                    NCK nck = new NCK();
                    Name = nck.Name;
                    Description = nck.Description;
                    Fields = nck.Fields;
                    break;
                case Segments.NDS:
                    NDS nds = new NDS();
                    Name = nds.Name;
                    Description = nds.Description;
                    Fields = nds.Fields;
                    break;
                case Segments.NK1:
                    NK1 nk1 = new NK1();
                    Name = nk1.Name;
                    Description = nk1.Description;
                    Fields = nk1.Fields;
                    break;
                case Segments.NPU:
                    NPU npu = new NPU();
                    Name = npu.Name;
                    Description = npu.Description;
                    Fields = npu.Fields;
                    break;
                case Segments.NSC:
                    NSC nsc = new NSC();
                    Name = nsc.Name;
                    Description = nsc.Description;
                    Fields = nsc.Fields;
                    break;
                case Segments.NST:
                    NST nst = new NST();
                    Name = nst.Name;
                    Description = nst.Description;
                    Fields = nst.Fields;
                    break;
                case Segments.NTE:
                    NTE nte = new NTE();
                    Name = nte.Name;
                    Description = nte.Description;
                    Fields = nte.Fields;
                    break;
                case Segments.OBR:
                    OBR obr = new OBR();
                    Name = obr.Name;
                    Description = obr.Description;
                    Fields = obr.Fields;
                    break;
                case Segments.OBX:
                    OBX obx = new OBX();
                    Name = obx.Name;
                    Description = obx.Description;
                    Fields = obx.Fields;
                    break;
                case Segments.ODS:
                    ODS ods = new ODS();
                    Name = ods.Name;
                    Description = ods.Description;
                    Fields = ods.Fields;
                    break;
                case Segments.ODT:
                    ODT odt = new ODT();
                    Name = odt.Name;
                    Description = odt.Description;
                    Fields = odt.Fields;
                    break;
                case Segments.OM1:
                    OM1 om1 = new OM1();
                    Name = om1.Name;
                    Description = om1.Description;
                    Fields = om1.Fields;
                    break;
                case Segments.OM2:
                    OM2 om2 = new OM2();
                    Name = om2.Name;
                    Description = om2.Description;
                    Fields = om2.Fields;
                    break;
                case Segments.OM3:
                    OM3 om3 = new OM3();
                    Name = om3.Name;
                    Description = om3.Description;
                    Fields = om3.Fields;
                    break;
                case Segments.OM4:
                    OM4 om4 = new OM4();
                    Name = om4.Name;
                    Description = om4.Description;
                    Fields = om4.Fields;
                    break;
                case Segments.OM5:
                    OM5 om5 = new OM5();
                    Name = om5.Name;
                    Description = om5.Description;
                    Fields = om5.Fields;
                    break;
                case Segments.OM6:
                    OM6 om6 = new OM6();
                    Name = om6.Name;
                    Description = om6.Description;
                    Fields = om6.Fields;
                    break;
                case Segments.OM7:
                    OM7 om7 = new OM7();
                    Name = om7.Name;
                    Description = om7.Description;
                    Fields = om7.Fields;
                    break;
                case Segments.ORC:
                    ORC orc = new ORC();
                    Name = orc.Name;
                    Description = orc.Description;
                    Fields = orc.Fields;
                    break;
                case Segments.ORG:
                    ORG org = new ORG();
                    Name = org.Name;
                    Description = org.Description;
                    Fields = org.Fields;
                    break;
                case Segments.OVR:
                    OVR ovr = new OVR();
                    Name = ovr.Name;
                    Description = ovr.Description;
                    Fields = ovr.Fields;
                    break;
                case Segments.PCR:
                    PCR pcr = new PCR();
                    Name = pcr.Name;
                    Description = pcr.Description;
                    Fields = pcr.Fields;
                    break;
                case Segments.PD1:
                    PD1 pd1 = new PD1();
                    Name = pd1.Name;
                    Description = pd1.Description;
                    Fields = pd1.Fields;
                    break;
                case Segments.PDA:
                    PDA pda = new PDA();
                    Name = pda.Name;
                    Description = pda.Description;
                    Fields = pda.Fields;
                    break;
                case Segments.PDC:
                    PDC pdc = new PDC();
                    Name = pdc.Name;
                    Description = pdc.Description;
                    Fields = pdc.Fields;
                    break;
                case Segments.PEO:
                    PEO peo = new PEO();
                    Name = peo.Name;
                    Description = peo.Description;
                    Fields = peo.Fields;
                    break;
                case Segments.PES:
                    PES pes = new PES();
                    Name = pes.Name;
                    Description = pes.Description;
                    Fields = pes.Fields;
                    break;
                case Segments.PID:
                    PID pid = new PID();
                    Name = pid.Name;
                    Description = pid.Description;
                    Fields = pid.Fields;
                    break;
                case Segments.PR1:
                    PR1 pr1 = new PR1();
                    Name = pr1.Name;
                    Description = pr1.Description;
                    Fields = pr1.Fields;
                    break;
                case Segments.PRA:
                    PRA pra = new PRA();
                    Name = pra.Name;
                    Description = pra.Description;
                    Fields = pra.Fields;
                    break;
                case Segments.PRB:
                    PRB prb = new PRB();
                    Name = prb.Name;
                    Description = prb.Description;
                    Fields = prb.Fields;
                    break;
                case Segments.PRC:
                    PRC prc = new PRC();
                    Name = prc.Name;
                    Description = prc.Description;
                    Fields = prc.Fields;
                    break;
                case Segments.PRD:
                    PRD prd = new PRD();
                    Name = prd.Name;
                    Description = prd.Description;
                    Fields = prd.Fields;
                    break;
                case Segments.PSH:
                    PSH psh = new PSH();
                    Name = psh.Name;
                    Description = psh.Description;
                    Fields = psh.Fields;
                    break;
                case Segments.PTH:
                    PTH pth = new PTH();
                    Name = pth.Name;
                    Description = pth.Description;
                    Fields = pth.Fields;
                    break;
                case Segments.PV1:
                    PV1 pv1 = new PV1();
                    Name = pv1.Name;
                    Description = pv1.Description;
                    Fields = pv1.Fields;
                    break;
                case Segments.PV2:
                    PV2 pv2 = new PV2();
                    Name = pv2.Name;
                    Description = pv2.Description;
                    Fields = pv2.Fields;
                    break;
                case Segments.QAK:
                    QAK qak = new QAK();
                    Name = qak.Name;
                    Description = qak.Description;
                    Fields = qak.Fields;
                    break;
                case Segments.QID:
                    QID qid = new QID();
                    Name = qid.Name;
                    Description = qid.Description;
                    Fields = qid.Fields;
                    break;
                case Segments.QPD:
                    QPD qpd = new QPD();
                    Name = qpd.Name;
                    Description = qpd.Description;
                    Fields = qpd.Fields;
                    break;
                case Segments.QRD:
                    QRD qrd = new QRD();
                    Name = qrd.Name;
                    Description = qrd.Description;
                    Fields = qrd.Fields;
                    break;
                case Segments.QRF:
                    QRF qrf = new QRF();
                    Name = qrf.Name;
                    Description = qrf.Description;
                    Fields = qrf.Fields;
                    break;
                case Segments.QRI:
                    QRI qri = new QRI();
                    Name = qri.Name;
                    Description = qri.Description;
                    Fields = qri.Fields;
                    break;
                case Segments.RCP:
                    RCP rcp = new RCP();
                    Name = rcp.Name;
                    Description = rcp.Description;
                    Fields = rcp.Fields;
                    break;
                case Segments.RDF:
                    RDF rdf = new RDF();
                    Name = rdf.Name;
                    Description = rdf.Description;
                    Fields = rdf.Fields;
                    break;                
                case Segments.RF1:
                    RF1 rf1 = new RF1();
                    Name = rf1.Name;
                    Description = rf1.Description;
                    Fields = rf1.Fields;
                    break;
                case Segments.RGS:
                    RGS rgs = new RGS();
                    Name = rgs.Name;
                    Description = rgs.Description;
                    Fields = rgs.Fields;
                    break;
                case Segments.RMI:
                    RMI rmi = new RMI();
                    Name = rmi.Name;
                    Description = rmi.Description;
                    Fields = rmi.Fields;
                    break;
                case Segments.ROL:
                    ROL rol = new ROL();
                    Name = rol.Name;
                    Description = rol.Description;
                    Fields = rol.Fields;
                    break;
                case Segments.RQ1:
                    RQ1 rq1 = new RQ1();
                    Name = rq1.Name;
                    Description = rq1.Description;
                    Fields = rq1.Fields;
                    break;
                case Segments.RQD:
                    RQD rqd = new RQD();
                    Name = rqd.Name;
                    Description = rqd.Description;
                    Fields = rqd.Fields;
                    break;
                case Segments.RXA:
                    RXA rxa = new RXA();
                    Name = rxa.Name;
                    Description = rxa.Description;
                    Fields = rxa.Fields;
                    break;
                case Segments.RXC:
                    RXC rxc = new RXC();
                    Name = rxc.Name;
                    Description = rxc.Description;
                    Fields = rxc.Fields;
                    break;
                case Segments.RXD:
                    RXD rxd = new RXD();
                    Name = rxd.Name;
                    Description = rxd.Description;
                    Fields = rxd.Fields;
                    break;
                case Segments.RXE:
                    RXE rxe = new RXE();
                    Name = rxe.Name;
                    Description = rxe.Description;
                    Fields = rxe.Fields;
                    break;
                case Segments.RXG:
                    RXG rxg = new RXG();
                    Name = rxg.Name;
                    Description = rxg.Description;
                    Fields = rxg.Fields;
                    break;
                case Segments.RXO:
                    RXO rxo = new RXO();
                    Name = rxo.Name;
                    Description = rxo.Description;
                    Fields = rxo.Fields;
                    break;
                case Segments.RXR:
                    RXR rxr = new RXR();
                    Name = rxr.Name;
                    Description = rxr.Description;
                    Fields = rxr.Fields;
                    break;
                case Segments.SAC:
                    SAC sac = new SAC();
                    Name = sac.Name;
                    Description = sac.Description;
                    Fields = sac.Fields;
                    break;
                case Segments.SCH:
                    SCH sch = new SCH();
                    Name = sch.Name;
                    Description = sch.Description;
                    Fields = sch.Fields;
                    break;
                case Segments.SFT:
                    SFT sft = new SFT();
                    Name = sft.Name;
                    Description = sft.Description;
                    Fields = sft.Fields;
                    break;
                case Segments.SID:
                    SID sid = new SID();
                    Name = sid.Name;
                    Description = sid.Description;
                    Fields = sid.Fields;
                    break;
                case Segments.SPM:
                    SPM spm = new SPM();
                    Name = spm.Name;
                    Description = spm.Description;
                    Fields = spm.Fields;
                    break;
                case Segments.SPR:
                    SPR spr = new SPR();
                    Name = spr.Name;
                    Description = spr.Description;
                    Fields = spr.Fields;
                    break;
                case Segments.STF:
                    STF stf = new STF();
                    Name = stf.Name;
                    Description = stf.Description;
                    Fields = stf.Fields;
                    break;
                case Segments.TCC:
                    TCC tcc = new TCC();
                    Name = tcc.Name;
                    Description = tcc.Description;
                    Fields = tcc.Fields;
                    break;
                case Segments.TCD:
                    TCD tcd = new TCD();
                    Name = tcd.Name;
                    Description = tcd.Description;
                    Fields = tcd.Fields;
                    break;
                case Segments.TQ1:
                    TQ1 tq1 = new TQ1();
                    Name = tq1.Name;
                    Description = tq1.Description;
                    Fields = tq1.Fields;
                    break;
                case Segments.TQ2:
                    TQ2 tq2 = new TQ2();
                    Name = tq2.Name;
                    Description = tq2.Description;
                    Fields = tq2.Fields;
                    break;
                case Segments.TXA:
                    TXA txa = new TXA();
                    Name = txa.Name;
                    Description = txa.Description;
                    Fields = txa.Fields;
                    break;
                case Segments.UB1:
                    UB1 ub1 = new UB1();
                    Name = ub1.Name;
                    Description = ub1.Description;
                    Fields = ub1.Fields;
                    break;
                case Segments.UB2:
                    UB2 ub2 = new UB2();
                    Name = ub2.Name;
                    Description = ub2.Description;
                    Fields = ub2.Fields;
                    break;
                case Segments.URD:
                    URD urd = new URD();
                    Name = urd.Name;
                    Description = urd.Description;
                    Fields = urd.Fields;
                    break;
                case Segments.URS:
                    URS urs = new URS();
                    Name = urs.Name;
                    Description = urs.Description;
                    Fields = urs.Fields;
                    break;
                case Segments.VAR:
                    VAR var = new VAR();
                    Name = var.Name;
                    Description = var.Description;
                    Fields = var.Fields;
                    break;
                case Segments.VTQ:
                    VTQ vtq = new VTQ();
                    Name = vtq.Name;
                    Description = vtq.Description;
                    Fields = vtq.Fields;
                    break;
            }
        }
    }
}
